using Microsoft.AspNetCore.Mvc;
using MVCRep.Models.Repositories;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class HomeController(ITodoService todoService) : Controller
    {
        private readonly ITodoService _todoService = todoService;

        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAllTodosAsync();
            var completed = todos.Where(i => i.IsCompleted == true).ToList();
            ViewModel vm = new ViewModel()
            {
                AllTodos = todos,
                CompletedTodos = completed
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Add(ViewModel vm)
        {
            await _todoService.CreateAsync(vm.AddTodoView);
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            await _todoService.UpdateAsync(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompleted(string id)
        {
            await _todoService.UpdateCompleteAsync(id);
            return RedirectToAction("index");
        }
    }
}
