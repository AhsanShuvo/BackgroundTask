using BackgroundTask.Models;
using BackgroundTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BackgroundTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IFileService _fileService;
        private readonly ILogger _logger;
        public HomeController(IFileService fileService, IBackgroundTaskQueue taskQueue, ILogger<HomeController> logger)
        {
            _fileService = fileService;
            _taskQueue = taskQueue;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartUploading()
        {
            FileModel fileModel = _fileService.UploadFile();
            if (fileModel != null)
            {
                _taskQueue.QueueBackgroundWorkItem(async token =>
                {
                    await _fileService.UpdateStatus(fileModel.Id);
                });
                _logger.LogInformation("New item is pushed into background task queue");
                return RedirectToAction("Progress", new { id = fileModel.Id });
            }
            return BadRequest();
        }

        public IActionResult Progress()
        {
            return View();
        }

        public IActionResult ProcessingStatus(int id)
        {
            FileModel fileModel = _fileService.GetProgress(id);
            if (fileModel != null)
            {
                return Json(fileModel);
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
