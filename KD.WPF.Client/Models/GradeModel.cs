using Prism.Mvvm;
using System;

namespace KD.WPF.Client.Models
{
    public class GradeModel : BindableBase
    {

        #region Constructor
        public GradeModel()
        {
            Initialize();

        }
        #endregion Constructor

        #region Properties
        private Guid gradeId;
        public Guid GradeId
        {
            get { return gradeId; }
            set { SetProperty(ref gradeId, value); }
        }

        private double gradeValue;
        public double GradeValue
        {
            get { return gradeValue; }
            set { SetProperty(ref gradeValue, value); }
        }

        private DateTime? evaluationDate;
        public DateTime? EvaluationDate
        {
            get { return evaluationDate; }
            set { SetProperty(ref evaluationDate, value); }
        }

        private string observations;
        public string Observations
        {
            get { return observations; }
            set { SetProperty(ref observations, value); }
        }        
        #endregion Properties

        #region Methods
        protected void Initialize()
        {
        }
        #endregion Methods

    }
}
