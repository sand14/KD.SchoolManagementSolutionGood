using KD.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Course
{
    public interface ICourseService
    {
        CourseModel CreateCourse(CourseModel course);
        CourseModel GetCourseById(Guid courseId);
    }
}
