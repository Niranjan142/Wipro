using CustomerFeedbackPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerFeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        private static List<Feedback> feedbackList = new List<Feedback>();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return RedirectToAction("List");
            }

            return View(feedback);
        }

        public IActionResult List()
        {
            return View(feedbackList);
        }
    }
}
