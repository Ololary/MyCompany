using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;


namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);
        }
        [HttpPost]
        [RequestSizeLimit(10000000)]
        [AcceptVerbs("Get", "Post")]
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null&&IsFileValid(titleImageFile))
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }


        //Method to validate uppload files
        public static bool IsFileValid(IFormFile file)
        {
            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                var signatures = _fileSignatures.Values.SelectMany(x => x).ToList();  // flatten all signatures to single list
                var headerBytes = reader.ReadBytes(_fileSignatures.Max(m => m.Value.Max(n => n.Length)));
                bool result = signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
                return result;
            }
        }

        private static readonly Dictionary<string, List<byte[]>> _fileSignatures = new()
{
    { ".gif", new List<byte[]> { new byte[] { 0x47, 0x49, 0x46, 0x38 } } },
    { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
    { ".jpeg", new List<byte[]>
        {
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
        }
    },
    { ".jpeg2000", new List<byte[]> { new byte[] { 0x00, 0x00, 0x00, 0x0C, 0x6A, 0x50, 0x20, 0x20, 0x0D, 0x0A, 0x87, 0x0A } } },

    { ".jpg", new List<byte[]>
        {
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
        }
    },
};
    }
}