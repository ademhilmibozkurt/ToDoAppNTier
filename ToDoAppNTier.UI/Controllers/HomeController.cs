using Microsoft.AspNetCore.Mvc;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.UI.Extensions;

// IWorkService
// WorkCreateDto
// WorkUpdateDto

namespace ToDoAppNTier.UI.Controllers
{
    // HomeController is a controller
    public class HomeController : Controller
    {
        // create IWorkService instance
        private readonly IWorkService _workService;
        // private readonly IMapper _mapper;

        // constructor Dependency Injection
        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        // asyncrhonic method. return response data(list of WorkDto. WorkDto is a specific work) to view(Index.cshtml).
        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        // create method returns a new WorkCreateDto instance
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        // post method for create operation. returns a WorkCreateDto response 
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            // create operation
            var response = await _workService.Create(dto);

            // go to Index and give response to view
            return this.ResponseRedirectToAction(response, "Index");
        }

        // Update method returns ResponseView. Find object will be updated
        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        // post method that updates object. push to db
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {   
            var response = await _workService.Update(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }
    }
}
