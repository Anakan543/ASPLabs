using Microsoft.AspNetCore.Mvc;

namespace Laborotorna7._1.Controllers
{
    public class FileController : Controller
    {
        public IActionResult FormURL()
        {
            return Redirect("/File/DownloadFile");
        }
        [HttpGet("/File/DownloadFile")]
        public IActionResult Form()
        {
            return View();
        }

        public IResult DownloadFile(string firstName, string secondName, string fileName)
        {
            string path = $"Files/{fileName}.txt";
            string context = $"First name - {firstName}, Second name - {secondName}";

            using (StreamWriter writer = new StreamWriter(path, append: false))
            {
                writer.WriteLine(context);
            }
            FileStream fileStream = new FileStream(path, FileMode.Open);
            return Results.File(fileStream, "txt", $"{fileName}.txt");
        }
    }
}
