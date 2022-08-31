using KD.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Student
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetStudents();
        StudentModel GetStudentById(Guid studentId);
        void DeleteStudent(Guid studentId);
        StudentModel CreateStudent(StudentModel student);
        StudentModel UpdateStudent(StudentModel student);
    }
}
