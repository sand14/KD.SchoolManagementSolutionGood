using Prism.Mvvm;
using System;

namespace KD.WPF.Client.Models
{
    public class CourseModel : BindableBase
    {
        #region Constructor
        public CourseModel()
        {
            Initialize();
        }
        #endregion Constructor
       
        #region Properties
        private Guid courseId;
        public Guid CourseId
        {
            get { return courseId; }
            set { SetProperty(ref courseId, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set { SetProperty(ref code, value); }
        } 
        
        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }        

        private int specializationId;
        public int SpecializationId
        {
            get { return specializationId; }
            set { SetProperty(ref specializationId, value); }
        }
        
        private bool optional;
        public bool Optional
        {
            get { return optional; }
            set { SetProperty(ref optional, value); }
        }
          
        private SpecializationModel? specialization;
        public SpecializationModel? Specialization
        {
            get { return specialization; }
            set { SetProperty(ref specialization, value); }
        }
        #endregion Properties

        #region Methods
        protected void Initialize()
        {
            InitializeComplexProperties();
        }
        
        protected void InitializeComplexProperties()
        {
            this.specialization = new SpecializationModel();            
        }
        #endregion Methods

    }
}
