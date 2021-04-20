using BackgroundTask.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BackgroundTask.Services
{
    public interface IFileService
    {
        FileModel UploadFile();
        Task UpdateStatus(int id);
        FileModel GetProgress(int id);
    }

    public class FileService : IFileService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger _logger;
        public FileService(IServiceScopeFactory serviceScopeFactory, ILogger<FileService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }
        public FileModel UploadFile()
        {

            FileModel fileModel = new FileModel
            {
                TotalChunk = 100,
                UploadedChunk = 0
            };
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var _context = scopedServices.GetRequiredService<TaskDbContext>();
                    _context.FileModel.Add(fileModel);
                    _context.SaveChanges();
                    _logger.LogInformation($"New entry is added into database with id {fileModel.Id}.");
                    return fileModel;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding new item into database. error: {ex.StackTrace}");
                return null;
            }
        }
        public async Task UpdateStatus(int id)
        {
            while (true)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var _context = scopedServices.GetRequiredService<TaskDbContext>();
                    FileModel model = _context.FileModel.Find(id);
                    if (model != null)
                    {
                        try
                        {
                            if (model.UploadedChunk < model.TotalChunk)
                            {
                                model.UploadedChunk += 5;
                                _context.Update(model);
                                _context.SaveChanges();
                                _logger.LogInformation($"Updated status of item {id}, total: {model.TotalChunk}, processed: {model.UploadedChunk}");
                                await Task.Delay(3000);
                            }
                            else
                            {
                                _logger.LogInformation($"Updating status of item {id} is finished");
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogInformation($"Error while updating status of item {id}, error: {ex.StackTrace}");
                            break;
                        }
                    }
                }
            }
        }

        public FileModel GetProgress(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var _context = scopedServices.GetRequiredService<TaskDbContext>();
                FileModel model = _context.FileModel.Find(id);
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }
    }
}
