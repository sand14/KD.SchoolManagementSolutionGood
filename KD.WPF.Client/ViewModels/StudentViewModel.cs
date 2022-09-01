using KD.WPF.Client.APIClient.RestServices;
using KD.WPF.Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KD.WPF.Client.ViewModels
{
    public class StudentViewModel : BindableBase
    {
        #region Properties
        private readonly StudentRestService studentRestService;

        private ObservableCollection<StudentModel> students;
        public ObservableCollection<StudentModel> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        private StudentModel selectedStudent;
        public StudentModel SelectedStudent
        {
            get { return selectedStudent; }
            set { SetProperty(ref selectedStudent, value); }
        }
        #endregion Properties
        public DelegateCommand DeleteStudentCommand { get; private set; }
        public DelegateCommand AddStudentCommand { get; private set; }
        public DelegateCommand UpdateStudentCommand { get; private set; }
        #region Constructor
        public StudentViewModel(StudentRestService studentRestService)
        {
            this.studentRestService = studentRestService;
            DeleteStudentCommand = new DelegateCommand(DeleteStudent);
            AddStudentCommand = new DelegateCommand(AddStudent);
            UpdateStudentCommand = new DelegateCommand(UpdateStudent);
            Task.Run(() => this.Initialize()).Wait();
        }

        private async void UpdateStudent()
        {
            if(selectedStudent == null)
            {
                MessageBox.Show("Please select the student you want to update");
                return;
            }

            //send updated model to server
            await studentRestService.UpdateStudentAsync(selectedStudent.StudentId, selectedStudent);

            //refresh list
            await GetStudents();
        }

        private async void AddStudent()
        {
            
            StudentModel newStudent = Students.FirstOrDefault(s => s.StudentId == Guid.Empty);
            if (newStudent == null)
            {
                MessageBox.Show("Please enter a student into the grid");
                return;
            }

            await studentRestService.CreateStudentAsync(newStudent);

            await GetStudents();

        }

        private async void DeleteStudent()
        {
            if(SelectedStudent == null)
            {
                MessageBox.Show("Please select a student");
                return;
            }
            Guid studentId = SelectedStudent.StudentId;
            await studentRestService.DeleteStudentAsync(studentId);

            await GetStudents();
        }
        #endregion Constructor

        #region Methods
        private async Task GetStudents()
        {
            Students = new ObservableCollection<StudentModel>(await studentRestService.GetAllStudentsAsync());
        }

        private async Task Initialize()
        {
            await GetStudents();

            //var testGetById = await studentRestService.GetStudentAsync(System.Guid.Parse("1517B7CF-0874-42F5-B23F-7E4F5A8D5B4B"));
            //await studentRestService.DeleteStudentAsync(System.Guid.Parse("D8AF4516-4088-41F6-80D0-DA47BB07EC1F"));

            //StudentModel student = new()
            //{
            //    FirstName = "Test Client",
            //    LastName = "Test Client Last",
            //    DateOfBirth = System.DateTime.Today.AddYears(-24)
            //};

            //var createTest = studentRestService.CreateStudentAsync(student);

            //var studentToUpdate = Students.First();
            //studentToUpdate.FirstName = "Gigi";
            //var testUpdate = await studentRestService.UpdateStudentAsync(studentToUpdate.StudentId, studentToUpdate);
        }
        #endregion Methods

        #region Commands
        #endregion Commands
    }
}
