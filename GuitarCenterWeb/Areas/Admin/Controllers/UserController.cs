using GuitarCenter.DataAccess.Repository.IRepository;
using GuitarCenter.Models;
using GuitarCenter.Models.ViewModels;
using GuitarCenter.Utility;
using GuitarCenterWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GuitarCenterWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult RoleManagment(string userId)
		{
			var userFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            RoleManagmentVM roleManagmentVM = new RoleManagmentVM()
            {
                ApplicationUser = userFromDb,
				RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
				{
					Text = i,
					Value = i
				}),
				CompanyList = _unitOfWork.Company.GetAll().Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				})
			};

            roleManagmentVM.ApplicationUser.Role = _userManager.GetRolesAsync(userFromDb).GetAwaiter().GetResult().FirstOrDefault();

			return View(roleManagmentVM);
		}

        [HttpPost]
		public IActionResult RoleManagment(RoleManagmentVM _roleManagmentVM)
		{
            var userFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == _roleManagmentVM.ApplicationUser.Id, tracked: true);
            string oldRole = _userManager.GetRolesAsync(userFromDb).GetAwaiter().GetResult().FirstOrDefault();
            string newRole = _roleManagmentVM.ApplicationUser.Role;

			if (oldRole != newRole)
            {
                _userManager.RemoveFromRoleAsync(userFromDb, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(userFromDb, newRole).GetAwaiter().GetResult();
            }

            if (oldRole != newRole && oldRole == SD.Role_Company)
            {
                userFromDb.CompanyId = null;
            }

            if (newRole == SD.Role_Company)
            {
                userFromDb.CompanyId = _roleManagmentVM.ApplicationUser.CompanyId;
            }

            _unitOfWork.ApplicationUser.Update(userFromDb);
            _unitOfWork.Save();

			return RedirectToAction("Index");   
		}


		#region API CALLS

		[HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Company").ToList();

            foreach(var user in objUserList)
            {
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                if(user.Company is null)
                {
                    user.Company = new Company() { 
                        Name = "" };
                }
            }

            return Json(new { data = objUserList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);   
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if(objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _unitOfWork.ApplicationUser.Update(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Operation Successful" });
        }

        #endregion
    }
}
