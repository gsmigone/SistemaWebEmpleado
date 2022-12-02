using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebEmpleado.Validations
{
    public class CheckValidLegajo : ValidationAttribute
    {
        public CheckValidLegajo()
        {
            ErrorMessage = ("El legajo siempre comienza con dos letras “AA” y 5 números. ");
        }

        public bool IsDigitsOnly(string str)
        {
            if(int.TryParse(str, out int legajo)){
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public override bool IsValid(object value)
        {
            string legajo = (string)value;
            legajo.Replace(" ", "");

            if (legajo.Substring(0, 2) == "AA" && IsDigitsOnly(legajo.Substring(2, 4)) && legajo.Length == 7)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



    }


}


