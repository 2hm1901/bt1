using bt1.Models;
using bt1.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace bt1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Profiles> _userManager;
        public AdminController(IUnitOfWork unitOfWork, UserManager<Profiles> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public string TakeIdUser()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            string userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
        public IActionResult ManagerAccount()
        {
            List<Profiles>? myList = _unitOfWork.ProfilesRepository.GetAll().Where(u => u.Id != TakeIdUser()).ToList();
            return View(myList);
        }
        public IActionResult Delete(string? data)
        {
            Profiles user = _unitOfWork.ProfilesRepository.Get(u => u.Id == data);
            _unitOfWork.ProfilesRepository.Delete(user);
            _unitOfWork.Save();
            return RedirectToAction("ManagerAccount");
        }
        public IActionResult ResetPass(string? data)
        {
            Profiles user = _unitOfWork.ProfilesRepository.Get(u => u.Id == data);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPass(string id, string pass)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetResult = await _userManager.ResetPasswordAsync(user, resetToken, pass);

            if (resetResult.Succeeded)
            {
                return RedirectToAction("ManagerAccount");
            }

            foreach (var error in resetResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }
        //Categories
        public IActionResult ManagerCategories()
        {
            List<Categories> myList = _unitOfWork.CategoriesRepository.GetAll().ToList();
            return View(myList);
        }
        public IActionResult CreateCategories()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategories(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoriesRepository.Add(categories);
                _unitOfWork.Save();
                return RedirectToAction("ManagerCategories");
            }
            return View(categories);
        }
        public IActionResult EditCategories(int id) {
            Categories? categories = _unitOfWork.CategoriesRepository.Get(c => c.Id == id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult EditCategories(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoriesRepository.Update(categories);
                _unitOfWork.Save();
                return RedirectToAction("ManagerCategories");
            }
            return View(categories);
        }

        public IActionResult DeleteCategories(int? id) {
            Categories? categories = _unitOfWork.CategoriesRepository.Get(c => c.Id == id);
            _unitOfWork.CategoriesRepository.Delete(categories);
            _unitOfWork.Save();
            return RedirectToAction("ManagerCategories");
        }
    }
}
