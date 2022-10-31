using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JsonLog
    {
        [Key]
        public int JsonId { get; set; }


        [Display(Name = "متن گزارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "{0} نمیتواند بیشتر از{1} کاراکتر باشد")]
        public string LogText { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
