using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;

namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            var sliders = _sliderService.GetAllSliders();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            _sliderService.AddSlider(slider);
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _sliderService.DeleteSlider(id);

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);

            if (existSlider == null)
            {
                return NotFound();
            }

            return View(existSlider);
        }
        public IActionResult Update(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);

            if (existSlider == null) throw new NullReferenceException();

            return View(existSlider);
        }

        [HttpPost]
        public IActionResult Update(Slider newSlider)
        {
            _sliderService.UpdateSlider(newSlider.Id, newSlider);
            return RedirectToAction("index");
        }
    }
}
