using System;
using System.ComponentModel.DataAnnotations;

namespace SchedulePlatform.WebUI.Validations
{
    public class EmailLength : ValidationAttribute
    {
        public int Value { get; set; }

        public override bool IsValid(object? value)
        {
            var emailDigits = value as string;

            string username = emailDigits.Split("@")[0];
            string domain = emailDigits.Split("@")[1];

            if (emailDigits?.Length == null)
            {
                return false;
            }

            if (username.Length < 3 || domain.Length < 4)
            {
                return false;
            }

            return true;
        }
    }
}

