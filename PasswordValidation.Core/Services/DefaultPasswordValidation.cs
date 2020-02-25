using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PasswordValidation.Core.Dtos;
using PasswordValidation.Core.Interfaces;

namespace PasswordValidation.Core.Services
{
    public class DefaultPasswordValidation : IPasswordRules
    {
        public GetPasswordDto Check(AddPasswordDto password)
        {
            GetPasswordDto passwordDto = new GetPasswordDto();
            var actions = new List<Func<bool>>();
            bool result = true;

            try
            {
                actions.Add(() => IsNullCondition(password.Password));
                actions.Add(() => LengthCondition(password.Password));
                actions.Add(() => DigitCondition(password.Password));
                actions.Add(() => LowercaseLetterCondition(password.Password));
                actions.Add(() => UppercaseLetterCondition(password.Password));
                actions.Add(() => SpecialCharacterCondition(password.Password));

                actions.ForEach(a => result &= a());

                passwordDto.IsValid = result;
            }
            catch(Exception)
            {
                passwordDto.IsValid = false;
            }

            return passwordDto;
        }

        private bool IsNullCondition(string password)
        {
            return String.IsNullOrEmpty(password) ? throw new ArgumentNullException() : true;
        }

        private bool LengthCondition(string password)
        {
            return password.Length >= 9 ? true : false;
        }

        private bool DigitCondition(string password)
        {
            return password.Any(char.IsDigit);
        }

        private bool LowercaseLetterCondition(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool UppercaseLetterCondition(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool SpecialCharacterCondition(string password)
        {
            return Regex.IsMatch(password, "[a-z0-9 ]+", RegexOptions.IgnoreCase);
        }
    }
}