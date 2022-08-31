using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.Data;
using KD.Core.DomainModels;
using KD.Services.Student;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace KD.Test.Services
{
    public class StudentServiceTests
    {    
        private EFCoreRepository<Student> studentRepository;
        private EFCoreRepository<Course> coursetRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            //Set up DbContext
            var options = new DbContextOptionsBuilder<SchoolContext>();
            options.UseSqlServer("Server=DESKTOP-F92FLLN\\SQLEXPRESS;Database=School;Trusted_Connection=True;");
            SchoolContext _dbContext = new SchoolContext(options.Options);

            //Set up Repos
            studentRepository = new(_dbContext);
            coursetRepository = new(_dbContext);

            //Set up Automapper
            AutoMapperConfiguration.Init();
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
        }

        [Test]
        public void GetStudentsTest()
        {
            //arrange
            StudentService service = GetService();

            //act
            var students = service.GetStudents();

            //assert
            Assert.That(students.Any());
        }

        [Test]
        public void CreateStudentTest()
        {
            //arrange
            StudentService service = GetService();
            Guid createdStudentId = Guid.Empty;
            try
            {
                CourseModel course = service.GetCourseById(Guid.Parse("51AD2E2F-4414-4F89-A0E5-01F5CA0598C4"));
                Student student = CreateStudentModel("Test", "Testulescu", DateTime.Today.AddYears(-35));

                //act
                StudentModel createdStudent = service.CreateStudent(student.ToModel());
                createdStudentId = createdStudent.StudentId;

                //assert
                Assert.That(createdStudent != null);
                Assert.That(createdStudent?.FirstName == student.FirstName);
                Assert.That(createdStudent?.LastName == student.LastName);
                //Assert.That(createdStudent?.Courses.Any() ?? false); //to be fixed later
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                service.DeleteStudent(createdStudentId);
            }
        }

        [Test]
        public void DeleteStudentTest()
        {
            //arrange
            StudentService service = GetService();
            StudentModel student = CreateStudentModel("Georger", "Georgescu", DateTime.Today.AddYears(-30)).ToModel();
            StudentModel createdStudent = service.CreateStudent(student);

            //act
            service.DeleteStudent(createdStudent.StudentId);

            //assert
            var deletedStudent = service.GetStudentById(createdStudent.StudentId);
            Assert.That(deletedStudent == null);
        }

        private Student CreateStudentModel(string firstName, string lastName, DateTime dateOfBirth, Course course = null)
        {
            KD.Core.DomainModels.Student student = new()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            if (course != null)
                student.Courses.Add(course);

            return student;
        }

        private StudentService GetService()
        {
            return new (studentRepository, coursetRepository);
        }
    }
}