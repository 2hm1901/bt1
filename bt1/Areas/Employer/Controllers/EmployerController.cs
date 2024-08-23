using bt1.Models;
using bt1.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace bt1.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Authorize(Roles = "Employer")]
    public class EmployerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Profiles> _userManager;
        public EmployerController(IUnitOfWork unitOfWork, UserManager<Profiles> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult ManagerJob()
        {
            List<Jobs> myList = _unitOfWork.JobsRepository.GetAll().Where(u => u.userId == _userManager.GetUserId(User)).ToList();
            return View(myList);
        }
        public IActionResult Postjob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Postjob(Jobs job)
        {
            job.userId = _userManager.GetUserId(User);
            _unitOfWork.JobsRepository.Add(job);
            _unitOfWork.Save();
            return RedirectToAction("ManagerJob");
        }
        public IActionResult Delete(int? data)
        {
            Jobs job = _unitOfWork.JobsRepository.Get(u => u.id == data);
            List<JobApplications> myList = _unitOfWork.JobApplicationsRepository.GetAll().Where(u => u.jobId == data).ToList();
            _unitOfWork.JobsRepository.Delete(job);
            foreach (var item in myList)
            {
                _unitOfWork.JobApplicationsRepository.Delete(item);
            }
            _unitOfWork.Save();
            return RedirectToAction("ManagerJob");
        }
        public IActionResult ViewApplication(int? data)
        {
            ViewBag.JobId = data;
            List<JobApplications> listApplication = _unitOfWork.JobApplicationsRepository.GetAll().Where(a => a.jobId == data).ToList();
            List<Profiles> listUser = new List<Profiles>();
            foreach (var apply in listApplication)
            {
                if (apply.status == "Processing")
                {
                    listUser.Add(_unitOfWork.ProfilesRepository.Get(u => u.Id == apply.userId));
                }
            }
            return View(listUser);
        }
        public IActionResult Rejected(int? id, string? data)
        {
            JobApplications apply = _unitOfWork.JobApplicationsRepository.Get(a => a.jobId == id && a.userId == data);
            apply.status = "Rejected";
            _unitOfWork.JobApplicationsRepository.Update(apply);
            _unitOfWork.Save();

            return RedirectToAction("ViewApplication", new { data = id });
        }
        public IActionResult Approved(int? id, string? data)
        {
            JobApplications apply = _unitOfWork.JobApplicationsRepository.Get(a => a.jobId == id && a.userId == data);
            apply.status = "Approved";
            _unitOfWork.JobApplicationsRepository.Update(apply);
            _unitOfWork.Save();

            return RedirectToAction("ViewApplication", new { data = id });
        }
    }
}
