using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.ValidationCustom
{
    public class IsEmailAttribute : ValidationAttribute, IClientValidatable
    {
        bool invalid = false;
        private readonly object _valueToCompare;


        public override bool IsValid(object value)
        {
            invalid = false;

            if (String.IsNullOrEmpty(value.ToString()))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                value = Regex.Replace(value.ToString(), @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(value.ToString(),
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = this.FormatErrorMessage(metadata.DisplayName),
                ValidationType = "equal"
            };

            rule.ValidationParameters.Add("valuetocompare", this._valueToCompare);

            yield return rule;
        }
    }
}