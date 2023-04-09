using System;
using System.ComponentModel.DataAnnotations;

namespace SchedulePlatform.Shared.Validations
{
    public class PhoneLength : ValidationAttribute
    {
        public int Value { get; set; }

        public override bool IsValid(object? value)
        {
            var intValue = value as string;

            if (intValue == null)
            {
                return false;
            }
            if (intValue.Length < Value)
            {
                return false;
            }
            if (intValue.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}

