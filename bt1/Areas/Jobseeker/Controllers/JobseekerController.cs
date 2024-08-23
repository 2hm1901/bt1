using bt1.Models;
using bt1.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace bt1.Areas.Jobseeker.Controllers
{
    [Area("Jobseeker")]
    [Authorize(Roles = "Jobseeker")]
    public class JobseekerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Profiles> _userManager;
        public JobseekerController(IUnitOfWork unitOfWork, UserManager<Profiles> userManager)
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
        public IActionResult Apply(int? data)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            else
            {
                string currentTime = DateTime.Now.ToShortDateString();
                JobApplications application = new JobApplications
                {
                    jobId = (int)data,
                    userId = TakeIdUser(),
                    date = currentTime,
                    status = "Processing"
                };
                _unitOfWork.JobApplicationsRepository.Add(application);
                _unitOfWork.Save();

                return RedirectToAction("Index", "Home", new { area = "User" });
            }
        }
        public IActionResult ListAppliedJob()
        {
            string userId = TakeIdUser();
            List<JobApplications> listApply = _unitOfWork.JobApplicationsRepository.GetAll().Where(Application => Application.userId == userId).ToList();
            foreach (var obj in listApply)
            {
                var job = _unitOfWork.JobsRepository.Get(j => j.id == obj.jobId);
                obj.Job = job;
            }
            return View(listApply);
        }
    }
}
