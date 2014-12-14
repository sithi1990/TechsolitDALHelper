using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Techsolit.Validations
{
    public class ValidationException:Exception
    {
        public ValidationException(List<ErrorResult> vr1)
        {
            vr = vr1;
        }

        List<ErrorResult> vr = new List<ErrorResult>();
        public List<ErrorResult> ErrorResults
        {
            get { return vr; }
            set { vr = value; }
        }

    }
}
