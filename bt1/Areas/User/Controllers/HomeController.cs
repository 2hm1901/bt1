using bt1.Models;
using bt1.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace bt1.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Profiles> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork, UserManager<Profiles> userManager, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
        }
        public string TakeIdUser()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            string userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }

        public IActionResult Index()
        {
            List<Jobs> myList = _unitOfWork.JobsRepository.GetAll().ToList();
            return View(myList);
        }
        [HttpPost]
        public IActionResult Index(string search)
        {
            List<Jobs> myList = _unitOfWork.JobsRepository
                .GetAll()
                .Where(x => x.title.ToLower().Contains(search.ToLower()))
                .ToList();
            return View(myList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
