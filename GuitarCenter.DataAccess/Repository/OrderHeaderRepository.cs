using GuitarCenter.DataAccess.Repository.IRepository;
using GuitarCenter.Models;
using GuitarCenterWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.DataAccess.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
		private ApplicationDbContext _db;
		public OrderHeaderRepository(ApplicationDbContext db) :base(db)
		{
			_db = db;
		}

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderFromDb != null)
            {
				orderFromDb.OrderStatus = orderStatus;
				if(!string.IsNullOrEmpty(paymentStatus))
				{
					orderFromDb.PaymentStatus = paymentStatus;
				}
            }
        }

		public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
			if (!string.IsNullOrEmpty(sessionId))
			{
				orderFromDb.SessionId = sessionId;
			}
			if (!string.IsNullOrEmpty(paymentIntentId))
			{
				orderFromDb.PaymentIntentId = paymentIntentId;
				orderFromDb.PaymentDate = DateTime.Now;
			}
		}
	}
}
