using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Techsolit.Validations
{
    public class Validation
    {
       // bool isvalid;

        public static void Validate()
        {
          
                if (tempres.Count > 0)
                {
                    res = tempres;
                    tempres = new List<ErrorResult>();
                    throw new ValidationException(res);
                }
           
        }

        static List<ErrorResult> tempres = new List<ErrorResult>();
        static List<ErrorResult> res = new List<ErrorResult>();

        public static void EMailField(object value,string eid,string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
            }
            else
            {
                string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                 + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                 [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                 + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                 + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
                if (Regex.IsMatch(value.ToString(), pattern))
                {
                }
                else
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        

        public static void NotNull(object value, string eid, string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
                tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
            }
        }

        public static void AddError(string eid, string errormessage)
        {
           
             tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
            
        }

        public static void SLTelephoneField(object value, string eid, string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
            }
            else
            {
                string pattern = @"^0?\d{9}$";
                if (Regex.IsMatch(value.ToString(), pattern))
                {
                }
                else
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        public static void NICField(object value, string eid, string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
            }
            else
            {
                string pattern = @"^\d{9}[v|V]$";
                if (Regex.IsMatch(value.ToString(), pattern))
                {
                }
                else
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        public static void CustomField(object value, string expression, string eid, string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
            }
            else
            {
                string pattern = expression;
                if (Regex.IsMatch(value.ToString(), pattern))
                {
                }
                else
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        public static void NumericDouble(object value,string eid, string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
            }
            else
            {
               try
               {
                   double.Parse(value.ToString());
               }
                catch
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        public static void DateField(object value, string eid, string errormessage)
        {
            if (value == null || value.ToString() == "")
            {
            }
            else
            {
               try
               {
                   DateTime.Parse(value.ToString());
               }
               catch
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        public static void PasswordCheck(object chkfrom, object chkto,string eid, string errormessage)
        {
            if (chkto == null || chkto.ToString() == "")
            {
            }
            else
            {
                if (chkfrom.ToString() == chkto.ToString())
                {
                    
                }
               else
                {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
                }
            }
        }

        public static void CaptchaValidate(bool value, string eid, string errormessage)
        {
            if (value)
            {
            }
        
            else
            {
                    tempres.Add(new ErrorResult() { ErrorID = eid, ErrorMessage = errormessage });
               
            }
        }

    }
}
