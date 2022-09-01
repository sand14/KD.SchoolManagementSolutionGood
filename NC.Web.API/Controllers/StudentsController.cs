using KD.Common.Model.Models;
using KD.Services.Student;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NC.Web.API.Controllers
{
    [Authorize]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [Route("/api/Students")]
        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            try
            {
                var students = studentService.GetStudents();

                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [AllowAnonymous]
        [Route("/api/Students/{studentId}")]
        [HttpGet]
        public StudentModel Get(Guid studentId)
        {
            try
            {
                var student = studentService.GetStudentById(studentId);

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        [Route("/api/Students/{studentId}")]
        [HttpDelete]
        public void Delete(Guid studentId)
        {
            try
            {
                studentService.DeleteStudent(studentId);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        [Route("/api/Students")]
        [HttpPost]
        public StudentModel Create(StudentModel student)
        {
            try
            {
                //var studentModel = JsonSerializer.Deserialize<StudentModel>(student);
                StudentModel createdStudent = studentService.CreateStudent(student);                
                return createdStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [Route("/api/Students/{studentId}")]
        [HttpPut]
        public StudentModel Update(Guid studentId, [FromBody] JsonElement student)
        {
            try
            {
                var studentModel = JsonSerializer.Deserialize<StudentModel>(student);
                StudentModel updatedStudent = studentService.UpdateStudent(studentModel);
                return updatedStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
