using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Areas.Admin.ViewModels.Slider;
using Fiorello.Data;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderVM> sliderList = new();

            List<Slider> sliders = await _context.sliders.ToListAsync();

            foreach (Slider slider in sliders)
            {
                SliderVM model = new()
                {
                    Id = slider.Id,
                    Image = slider.Image,
                    Status = slider.Status,
                    CreateDate = slider.CreatedDate.ToString("dd-MM-yyyy")
                };

                sliderList.Add(model);
            }

            return View(sliderList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Slider dbSlider = await _context.sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (dbSlider is null) return NotFound();

            SliderDetailVM model = new()
            {
                Image = dbSlider.Image,
                CreateDate = dbSlider.CreatedDate.ToString("dd-MM-yyyy"),
                Status = dbSlider.Status,
            };

            return View(model);


        }

    }
}

