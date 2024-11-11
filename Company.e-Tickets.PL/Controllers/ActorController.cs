using AutoMapper;
using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.BLL.Repositories;
using Company.e_Tickets.PL.Helpers;
using Company.e_Tickets.PL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.e_Tickets.PL.Controllers
{
    public class ActorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Actors = await _unitOfWork.ActorRepository.GetAllAsync();
            var MappedActors = Actors.Select(actor => new ActorViewModel
            {
                Id= actor.Id,
                FullName = actor.FullName,
                ProfilePictureURL = actor.ProfilePictureURL,
                Bio = actor.Bio


            }).ToList();

            return View(MappedActors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel model)
        {

           
                model.ProfilePictureURL = DocumentSetting.UploadFile(model.Image, "Imgs");
                var MappedActor = _mapper.Map<ActorViewModel, Actor>(model);
                await _unitOfWork.ActorRepository.AddAsync(MappedActor);
                var result = await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            
            
            
        }

        public async Task<IActionResult> Details(int id, string ViewName = "Details")
        {

            var actor = await _unitOfWork.ActorRepository.GetByIdAsync(id);
            if (actor == null)
                return NotFound();
            var MappedActor = _mapper.Map<Actor, ActorViewModel>(actor);
            return View(ViewName, MappedActor);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ActorViewModel model, [FromRoute] int id)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            //if (ModelState.IsValid)
            //{
            try
            {
              if(model.Image is not null)
                {
                    model.ProfilePictureURL = DocumentSetting.UploadFile(model.Image, "Imgs");
                }
                var MappedActor = _mapper.Map<ActorViewModel, Actor>(model);
                _unitOfWork.ActorRepository.Update(MappedActor);
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
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ActorViewModel model, [FromRoute] int id)
        {
          
            if (id != model.Id)
            {
                return BadRequest();
            }
            try
            {
               
                var MappedActor = _mapper.Map<ActorViewModel, Actor>(model);
                _unitOfWork.ActorRepository.Delete(MappedActor);
                var Result = await _unitOfWork.CompleteAsync();
                if(Result > 0)
                {
                    if (model.ProfilePictureURL is not null)
                        DocumentSetting.DeleteFile(model.ProfilePictureURL, "Imgs");
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
          
            return RedirectToAction(nameof(Index));
        }




    }
}
