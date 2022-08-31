using KD.Common.Model.Models;
using KD.Services.Course;
using KD.Services.Student;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NC.Web.API.Controllers
{
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

       

        [Route("/api/Courses/{courseId}")]
        [HttpGet]
        public CourseModel Get(Guid courseId)
        {
            try
            {
                var course= courseService.GetCourseById(courseId);

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }





        [Route("/api/Courses")]
        [HttpPost]
        public CourseModel Create([FromBody] CourseModel course)
        {
            try
            {
                //var studentModel = JsonSerializer.Deserialize<StudentModel>(student);
                CourseModel createdCourse = courseService.CreateCourse(course);                
                return createdCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
