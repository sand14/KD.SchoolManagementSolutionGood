using AutoMapper;
using KD.Common.Model.Models;
using KD.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Common.Model.Automapper.Resolvers
{
    public class FullNameResolver : IValueResolver<Student, StudentModel, string>
    {
        public string Resolve(Student source, StudentModel destination, string destMember, ResolutionContext context)
        {
            return $"{source.FirstName} {source.LastName}";
        }
    }
}
