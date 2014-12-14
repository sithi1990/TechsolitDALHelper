using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Techsolit.Validations
{
    public class ErrorResult
    {
        string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
        private string validationid;

        public string ErrorID
        {
            get { return validationid; }
            set { validationid = value; }
        }


    }
}
