using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;
using ProniaTask.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Concretes
{
    public class SliderService : ISliderService
    {
        ISliderRepository _sliderRepository;

        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public async Task AddSlider(Slider slider)
        {
            await _sliderRepository.AddAsync(slider);
            await _sliderRepository.CommitAsync();
        }

        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);

            if (existSlider == null) throw new NullReferenceException("Slider tapilmadi...");

            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit();
        }

        public List<Slider> GetAllSliders(Func<Slider, bool>? predicate = null)
        {
            return _sliderRepository.GetAll();
        }

        public Slider GetSlider(Func<Slider, bool>? predicate = null)
        {
            return _sliderRepository.Get(predicate);
        }

        public void UpdateSlider(int id, Slider newSlider)
        {
            var oldSlider = _sliderRepository.Get(x => x.Id == id);

            if (oldSlider == null) throw new NullReferenceException("Slider tapilmadi...");

            oldSlider.Title = newSlider.Title;
            oldSlider.ImageURL = newSlider.ImageURL;
            oldSlider.Sale = newSlider.Sale;
            oldSlider.ButtonName = newSlider.ButtonName;
            oldSlider.Description = newSlider.Description;
            _sliderRepository.Commit();
        }
    }

}
