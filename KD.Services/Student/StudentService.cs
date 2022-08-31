using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.Data;
using KD.Core.DomainModels;

namespace KD.Services.Student
{
    public class StudentService : IStudentService
    {
        #region Old
        //#region Fields
        ////private readonly SchoolContext _dbContext;

        //private readonly IRepository<Core.DomainModels.Student> studentRepository;
        //#endregion
        ////public StudentService(SchoolContext _dbContext)
        ////{
        ////    _dbContext = dbContext;

        ////}

        //public StudentService(IRepository<Core.DomainModels.Student> studentRepository)
        //{
        //    this.studentRepository = studentRepository;
        //}
        //#region Methods

        //public IEnumerable<StudentModel> GetStudents()
        //{
        //    var students = studentRepository.Table.Select(x => x.ToModel()).ToList();
        //    return students;
        //}

        ////public StudentModel CreateStudent()
        ////{
        ////    var course = _dbContext.Courses.First(x => x.CourseId == new Guid("51AD2E2F-4414-4F89-A0E5-01F5CA0598C4"));
        ////    var student = new KD.Core.DomainModels.Student()
        ////    {
        ////        FirstName = "Miley",
        ////        LastName = "Jones",
        ////        DateOfBirth = new DateTime(2000,12,12),
        ////        Courses = new List<Course>()
        ////        {
        ////            course
        ////        }
        ////    };
        ////    _dbContext.Students.Add(student);
        ////    _dbContext.SaveChanges();
        ////    return null;
        ////}

        //#endregion
        #endregion Old

        #region New
        #region Fields
        private readonly IRepository<Core.DomainModels.Student> studentRepository;
        private readonly IRepository<Core.DomainModels.Course> courseRepository;


        #endregion
        public StudentService(IRepository<Core.DomainModels.Student> studentRepository,
                              IRepository<Core.DomainModels.Course> courseRepository
            )
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }


        #region Methods

        public IEnumerable<StudentModel> GetStudents()
        {
            var students = studentRepository.Table.Select(x => x.ToModel()).ToList();
            return students;
        }

        public StudentModel CreateStudent(StudentModel student)
        {
            if (student == null) return null;

            KD.Core.DomainModels.Student studentEntity = student.ToEntity();
            studentRepository.Insert(studentEntity);            

            StudentModel createdStudent = GetStudentById(studentEntity.StudentId);
            return createdStudent;
        }

        public StudentModel GetStudentById(Guid studentId)
        {            
            var student = studentRepository.Table.FirstOrDefault(s => s.StudentId == studentId);
            return student.ToModel();           
        }

        public StudentModel UpdateStudent(StudentModel student)
        {
            if (student == null) return null;
            var databaseEntity = studentRepository.TableNoTracking.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (databaseEntity == null) return null;

            studentRepository.Update(student.ToEntity());
            return GetStudentById(student.StudentId);
        }

        public void DeleteStudent(Guid studentId)
        {
            var databaseEntity = studentRepository.Table.FirstOrDefault(s => s.StudentId == studentId);
            if (databaseEntity == null) return;

            studentRepository.Delete(databaseEntity);          
        }

        public CourseModel GetCourseById(Guid courseId)
        {
            var course = courseRepository.TableNoTracking.FirstOrDefault(c => c.CourseId == courseId);
            return course.ToModel();
        }
        #endregion
        #endregion New
    }
}
