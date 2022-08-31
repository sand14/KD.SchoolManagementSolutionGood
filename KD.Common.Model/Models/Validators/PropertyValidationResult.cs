using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace KD.Common.Model.Models.Validators
{
    public class PropertyValidationResult
    {
       public PropertyValidationResult()
        {
            this.Errors = new List<ValidationFailure>();
        }
        public bool isValid { get; set; }

        public IList<ValidationFailure> Errors { get; set; }
    }
}
