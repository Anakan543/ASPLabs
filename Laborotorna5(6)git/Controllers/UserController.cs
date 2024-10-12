using Microsoft.AspNetCore.Mvc;

namespace Laborotorna5_6_.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ShowInfo()
        {
            var formData = Request.Form;

            int count = int.Parse(Request.Cookies["countItems"]);

            _logger.LogInformation($"count - {count}");

            var items = new List<ItemModel>(); 
            for (int i = 1; i < count+1; i++)
            {
                _logger.LogInformation(formData[$"name{i}"]);
                _logger.LogInformation(formData[$"count{i}"]);
                string itemName = formData[$"name{i}"];
                //int.Parse(formData[$"count{i}"])
                string itemCount = formData[$"count{i}"];
                if (int.Parse(itemCount) <= 0)
                {
                    itemCount = "0";
                }

                items.Add(new ItemModel { Name = itemName, Count = itemCount });
            }

            return View(items);
        }
        [HttpPost]
        public IActionResult Forms(int countItem)
        {
            ViewData["countItems"] = countItem;
            Response.Cookies.Append("countItems", countItem.ToString());
            return View();
        }

        [HttpPost]
        public IActionResult CountItem(string name, int age)
        {
            ViewData["nameUser"] = name;
            ViewData["ageUser"] = age;
            return View();
        }
    }
    public class ItemModel
    {
        public string Name { get; set; }
        public string Count { get; set; }

        public override string ToString()
        {
            return $"Name - {Name}, count - {Count}";
        }
    }
}
