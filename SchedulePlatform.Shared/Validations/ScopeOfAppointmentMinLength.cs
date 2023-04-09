using System;
using System.ComponentModel.DataAnnotations;

namespace SchedulePlatform.Shared.Validations
{
    public class ScopeOfAppointmentMinLength : ValidationAttribute
    {
        public int Value { get; set; }

        public override bool IsValid(object? value)
        {
            var length = value as string;

            if (length.Length == null)
            {
                return false;
            }
            if (length.Length < Value)
            {
                return false;
            }

            return true;
        }
    }
}

