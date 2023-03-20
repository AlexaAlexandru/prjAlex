using System;
using System.ComponentModel.DataAnnotations;

namespace SchedulePlatform.WebUI.Validations
{
	public class FirstLastNameLength:ValidationAttribute
	{
        public int Value { get; set; }

        public override bool IsValid(object? value)
        {
            var nameLength = value as string;

            if (nameLength.Length == null)
            {
                return false;
            }
            if (nameLength.Length<Value)
            {
                return false;
            }

            return true;
        }
        
    }
}

