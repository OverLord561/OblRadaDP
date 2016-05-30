using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class Outlay
    {
        public int OutlayId { get; set; }

        [Required(ErrorMessage = "Вкажіть назву виконаної роботи")]
        public string OutlayTitle { get; set; }

        [Required(ErrorMessage = "Вкажіть організацію, на яку покладено відповідальність")]
        public string OutlayOrganization { get; set; }

        [Required(ErrorMessage = "Вкажіть суму витрат")]
        public string OutlayPrice { get; set; }

        [Required(ErrorMessage = "Вкажіть особу, відповідальну за виконання")]
        public string OutlayMan { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Вкажіть дату події")]
        public DateTime OutlayDate { get; set; }

        [StringLength(6000, MinimumLength = 7, ErrorMessage = "Потрібно вказати від 7 до 6000 символів")]
        public string OutlayContent { get; set; }

        public string OutlayPhoto { get; set; }

        
    }
}