using AutoMapper;
using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.PL.Helpers;
using Company.e_Tickets.PL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Company.e_Tickets.PL.Controllers
{
    [Authorize]
    public class ProducerController : Controller

    {
        
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public ProducerController(IUnitOfWork unitOfWork ,IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var Producers = await _unitOfWork.ProducerRepository.GetAllAsync();
            //ManualMapping
            //var MappedProducers = Producers.Select(Producer => new ProducerViewModel
            //{
            //    ProfilePictureURL = Producer.ProfilePictureURL,
            //    FullName = Producer.FullName,
            //    Bio = Producer.Bio
            //}).ToList();
            var MappedProducers = _mapper.Map<IEnumerable<Producer>,IEnumerable< ProducerViewModel>>(Producers);
            return View(MappedProducers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducerViewModel model)
        {
            model.ProfilePictureURL = DocumentSetting.UploadFile(model.Image, "Imgs");
            var MappedProdducer = _mapper.Map<ProducerViewModel, Producer>(model);
            await _unitOfWork.ProducerRepository.AddAsync(MappedProdducer);
            await _unitOfWork.CompleteAsync();
            
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details( int id , string ViewName = "Details" )
        {
         
          var producer = await _unitOfWork.ProducerRepository.GetByIdAsync(id);
            if (producer == null)
                return NotFound();
            var MappedProducer = _mapper.Map< Producer, ProducerViewModel>(producer);
            return View(ViewName,MappedProducer);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
          return await Details(id,"Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProducerViewModel model , [FromRoute] int id)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            //if (ModelState.IsValid)
            //{
                try
                {
                if (model.Image is not null)
                {
                    model.ProfilePictureURL = DocumentSetting.UploadFile(model.Image, "Imgs");
                }
                    var MappedProducer = _mapper.Map<ProducerViewModel, Producer>(model);
                    _unitOfWork.ProducerRepository.Update(MappedProducer);
                    await _unitOfWork.CompleteAsync();
                   
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
              
          //  }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
           return await Details(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProducerViewModel model , [FromRoute] int id)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }
            //if (ModelState.IsValid)
            //{
                try
                {
                   
                    var MappedProducer = _mapper.Map<ProducerViewModel, Producer>(model);
                     _unitOfWork.ProducerRepository.Delete(MappedProducer);
                   var Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                {
                    if (model.ProfilePictureURL is not null)
                        DocumentSetting.DeleteFile(model.ProfilePictureURL, "Imgs");
                }
            }
            catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty , ex.Message);
                }
           // }
            return RedirectToAction(nameof(Index));
        }




    }
}
