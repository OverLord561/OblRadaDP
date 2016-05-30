using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class Novelty
    {
        public int NoveltyId { get; set; }

        [Required(ErrorMessage = "Вкажіть заголовок для новини")]
        public string NoveltyTitle { get; set; }


        [StringLength(1000, MinimumLength = 7, ErrorMessage = "Потрібно вказати від 7 до 300 символів")]
        public string NoveltyShortContent { get; set; }


        [StringLength(6000, MinimumLength = 7, ErrorMessage = "Потрібно вказати від 7 до 6000 символів")]
        public string NoveltyContent { get; set; }



        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Вкажіть дату події")]
        public DateTime NoveltyDate { get; set; }

        public string NoveltyPhoto { get; set; }
    }
}