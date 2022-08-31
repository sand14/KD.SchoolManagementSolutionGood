using FluentValidation;
using KD.Common.Model.Models;
using KD.Common.Model.Models.Validators;
using KD.Core.Data;
using KD.Services.Course;
using KD.Services.Student;
using KD.Services.Teacher;
using System.ComponentModel.DataAnnotations;

namespace NC.Web.API
{
    public class DependencyRegistration
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="builder"></param>
        public void Register(IServiceCollection builder)
        {
            //Per request lifetime

            //Singleton services

            //Transient services

            builder.AddTransient(typeof(IRepository<>), typeof(EFCoreRepository<>));
            builder.AddTransient<IStudentService, StudentService>();
            builder.AddTransient<ITeacherService, TeacherService>();
            builder.AddTransient<ICourseService, CourseService>();


            builder.AddTransient<IValidator<StudentModel>, StudentModelValidator >();
            builder.AddTransient<IValidator<CourseModel>, CourseModelValidator >();
            builder.AddTransient<IValidator<SpecializationModel>, SpecializationModelValidator >();
        }

    }
}
