using KD.Common.Model.Models;
using KD.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KD.Common.Model.Automapper;

namespace KD.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Core.DomainModels.Course> courseRepository;



        public CourseService(IRepository<Core.DomainModels.Course> courseRepository)
        {
           
            this.courseRepository = courseRepository;
        }


        public CourseModel CreateCourse(CourseModel course)
        {
            if (course == null) return null;

            KD.Core.DomainModels.Course courseEntity = course.ToEntity();
            courseRepository.Insert(courseEntity);

            CourseModel createdCourse = GetCourseById(courseEntity.CourseId);
            return createdCourse;
        }

        public CourseModel GetCourseById(Guid courseId)
        {
            var course = courseRepository.Table.FirstOrDefault(s => s.CourseId == courseId);
            return course.ToModel();
        }
    }
}
