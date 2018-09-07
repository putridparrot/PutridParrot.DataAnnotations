using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PutridParrot.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ExpectedAttribute : ValidationAttribute
    {
        public ExpectedAttribute(object fromSet, bool generateErrorMessage = false)
        {
            FromSet = fromSet;
            GenerateErrorMessage = generateErrorMessage;
        }

        public object FromSet { get; set; }
        public bool GenerateErrorMessage { get; set; }

        public override bool IsValid(object value)
        {
            var array = FromSet as object[];
            var isValid = array?.Contains(value) ?? FromSet.Equals(value);
            if (GenerateErrorMessage)
            {
                ErrorMessage = CreateErrorMessage();
            }
            return isValid;
        }

        private string CreateErrorMessage()
        {
            return FromSet is object[] array ?
                $"Must be one of the following: {String.Join(", ", array.Select(a => a.ToString()))}" :
                $"Must be value {FromSet}";
        }
    }

}
