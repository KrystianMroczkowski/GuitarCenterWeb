using GuitarCenter.DataAccess.Repository.IRepository;
using GuitarCenter.Models;
using GuitarCenterWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.SerialNumber = obj.SerialNumber;
                objFromDb.Price = obj.Price;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Description = obj.Description;
				objFromDb.CategoryId = obj.CategoryId;
				objFromDb.Brand = obj.Brand;
                objFromDb.ProductImages = obj.ProductImages;
                //if (obj.ImageUrl != null) 
                //{
                //    objFromDb.ImageUrl = obj.ImageUrl;
                //}
			}
        }
    }
}
