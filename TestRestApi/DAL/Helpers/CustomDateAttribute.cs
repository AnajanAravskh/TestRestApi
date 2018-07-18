using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Helpers
{
    public class CustomDateAttribute: ValidationAttribute
    {
        public string StartDate { get; set; }
        //public CustomDateAttribute(object startDate)
        //{
        //    this.startDate = startDate.ToString();
        //}
        public override bool IsValid(object value)
        {
            if (!DateTime.TryParse(StartDate, out var sDate))
            {
                return false;
            }
            var dt = (DateTime)value;
            if (dt >= sDate)
            {
                return true;
            }
            return false;
        }
    }
}
