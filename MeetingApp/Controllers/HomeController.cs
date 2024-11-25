
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {

            int saat = DateTime.Now.Hour;
            ViewBag.selamlama = saat > 10 ? "Iyi Gunler" : "Gunaydin";
            //return View(model:selamlama);  selamlama bir model degil string oldugu icin basina model yazmaliyiz.
            int UserCount = Repository.Users.Where(i => i.WillAttend == true).Count();
            var meetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "Istanbul, Abc Kongre Merkesi",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = UserCount

            };
            return View(meetingInfo);// meetingInfo models oldugu icin tekrardan model diye onune yazmaya gerek yok
        }
    }
}