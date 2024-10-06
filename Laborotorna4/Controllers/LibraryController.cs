using Laborotorna4.service;
using Microsoft.AspNetCore.Mvc;

namespace Laborotorna4.Controllers
{
    public class LibraryController : Controller
    {
        public readonly BooksService _booksService;
        public readonly ProfileService _profileService;

        public LibraryController(BooksService booksService, ProfileService profileService)
        {
            _booksService = booksService;
            _profileService = profileService;
        }
        [HttpGet("Library/")]
        public IActionResult Index()
        {
            return Ok("Вітаємо в нашій бібліотеці!\n" +
                "/books/ - інформація про наявні книжки\n" +
                "/profile/ - інформація про профіль(/id = {id} - пошук за id)");
        }
        [HttpGet("Library/Books/")]
        public IActionResult Books()
        {
            return Ok(_booksService.ToString());
        }
        [HttpGet("Library/Books/genre = {genre}")]
        public IActionResult FindByGenre(string genre)
        {
            return Ok(_booksService.FindByGenre(genre));
        }
        [HttpGet("Library/Profile/")]
        public IActionResult NonID() {
            return Ok(_profileService.NonID());
        }
        [HttpGet("Library/Profile/ShowProfile/")]
        public IActionResult ShowProfiles()
        {
            return Ok(_profileService.ToString());
        }
        [HttpGet("Library/Profile/id = {id}")]
        public IActionResult Profiles(int id)
        {
            return Ok(_profileService.FindById(id));
        }
    }
}
