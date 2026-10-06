using Globomatics.Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Globomatics.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository repository;
        public CustomerController(ICustomerRepository repository) => this.repository = repository;
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
