using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace KD.WPF.Client.Models
{
    public class StudentModel : BindableBase
    {
        #region Constructor
        public StudentModel()
        {
            Initialize();
        }
        #endregion Constructor

        #region Properties
        private Guid studentId;
        public Guid StudentId
        {
            get { return studentId; }
            set { SetProperty(ref studentId, value); }
        } 
        
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }
        
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { SetProperty(ref dateOfBirth, value); }
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }


        private int identificationNumber;
        public int IdentificationNumber
        {
            get { return identificationNumber; }
            set { SetProperty(ref identificationNumber, value); }
        }

        private ObservableCollection<CourseModel> courses;
        public ObservableCollection<CourseModel> Courses
        {
            get { return courses; }
            set { SetProperty(ref courses, value); }
        }
        
        private ObservableCollection<GradeModel> grades;
        public ObservableCollection<GradeModel> Grades
        {
            get { return grades; }
            set { SetProperty(ref grades, value); }
        }
        #endregion Properties

        #region Methods
        protected void Initialize()
        {
            InitializeCollectionProperties();
        }

        protected void InitializeCollectionProperties()
        {
            this.courses = new ObservableCollection<CourseModel>();
            this.grades = new ObservableCollection<GradeModel>();
        }
        #endregion Methods

    }
}
