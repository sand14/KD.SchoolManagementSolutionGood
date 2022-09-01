using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.WPF.Client.ViewModels
{
    public class TeacherViewModel : BindableBase
    {
        private string viewName = "Teacher View";
        public string ViewName
        {
            get { return viewName; }
            set { SetProperty(ref viewName, value); }
        }
        public TeacherViewModel()
        {

        }
    }
}
