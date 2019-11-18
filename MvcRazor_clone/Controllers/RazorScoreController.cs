using MvcRazor_clone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRazor_clone.Controllers
{
    public class RazorScoreController : Controller
    {
        // GET: RazorScore
        public ActionResult Index()
        {
            return View();
        }
        protected List<Student> students = new List<Student>
        {
            new Student { Id =1, Name="Joe", Chinese=88, English=95, Math=71 },
            new Student { Id =12, Name="Mary", Chinese=92, English=82, Math=60 },
            new Student { Id =23, Name="Cathy", Chinese=98, English=91, Math=94 },
            new Student { Id =34, Name="John", Chinese=63, English=85, Math=55 },
            new Student { Id =45, Name="David", Chinese=59, English=77, Math=82 }
        };
        public ActionResult Scores()
        {
            return View(students);
        }
        public ActionResult ScoresRazor()
        {
            int topId = 0;
            int topScore = 0;

            foreach (var students in students)
            {
                //計算總分
                students.Total = students.Math + students.English + students.Chinese;
                //判斷總分最高者
                if (students.Total > topScore)
                {
                    topScore = students.Total;
                    topId = students.Id;
                }
            }
            //將最高分學生Id儲存到ViewBag，傳遞給View
            ViewBag.topId = topId;
            return View(students);
        }
    }
}