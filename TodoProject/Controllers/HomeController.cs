using Microsoft.AspNetCore.Mvc;
using MVCRep.Models.Dtos;
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
        public async Task<IActionResult> Add(string content)
        {
            AddTodoView todo = new AddTodoView()
            {
                Content = content,
                IsCompleted = false
            };
            await _todoService.CreateAsync(todo);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string content)
        {
            await _todoService.UpdateAsync(id, content);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompleted(string id)
        {
            await _todoService.UpdateCompleteAsync(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await _todoService.DeleteTodoAsync(id);
            return RedirectToAction("index");
        }
    }
}
