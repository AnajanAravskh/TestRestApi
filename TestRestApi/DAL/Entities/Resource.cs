using DAL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Resource {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int UpdatedBy { get; set; }
        [Range(0, 100)]
        public int CustomProperty1 { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Incorrect string length", MinimumLength = 6)]
        public string CustomProperty2 { get; set; }
        [CustomDate(StartDate = "2018/01/01", ErrorMessage = "Incorrect date")]
        public DateTime CustomProperty3 { get; set; }
        public decimal CustomProperty4 { get; set; }
        [CustomRequiredIf]
        public int? CustomProperty5 { get; set; }
        public string CustomProperty6 { get; set; }
        public DateTime CustomProperty7 { get; set; } }
}
