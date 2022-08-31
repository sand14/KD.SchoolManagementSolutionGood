using KD.Common.Model.Automapper;
using KD.Common.Model.Models;
using KD.Core.Data;
using KD.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        #region fields
        //private readonly SchoolContext _dbContext;
        #endregion
        private readonly IRepository<Core.DomainModels.Teacher> teacherRepository;

        #region constructor
        //public TeacherService(SchoolContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        #endregion

        public TeacherService(IRepository<Core.DomainModels.Teacher> teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        #region methods
        public IEnumerable<TeacherModel> GetTeachers()
        {
            var teachers = teacherRepository.Table.Select(x => x.ToModel()).AsEnumerable().OrderBy(d => d.DateOfBirth).ToList();
            return teachers;
        }

        public TeacherModel CreateTeacher(TeacherModel teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException();
            Core.DomainModels.Teacher teacherEntity = teacher.ToEntity();
            teacherRepository.Insert(teacherEntity);
            return teacherEntity.ToModel();
        }

        public TeacherModel GetTeacherById(Guid teacherId)
        {

            var teacher = teacherRepository.TableNoTracking.FirstOrDefault(x => x.TeacherId == teacherId);

            return teacher?.ToModel();
        }

        public void RemoveTeacher(Guid teacherId)
        {
            var teacherEntity = GetTeacherById(teacherId).ToEntity();
            if (teacherEntity == null) return;
            teacherRepository.Delete(teacherEntity);
        }

        public void UpdateTeacher(TeacherModel teacher)
        {
            if (teacher == null) throw new ArgumentNullException();
            var teacherDb = teacherRepository.TableNoTracking.FirstOrDefault(x => x.TeacherId == teacher.TeacherId);
            if (teacherDb == null) return;
            //teacherDb.CourseId = teacher.CourseId;
            //teacherDb.FirstName = teacher.FirstName;
            //teacherDb.LastName = teacher.LastName;
            var teacherEntity = teacher.ToEntity();
            teacherRepository.Update(teacherEntity);

        }
        #endregion
    }
}
