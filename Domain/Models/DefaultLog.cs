using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DefaultLog
    {

        [Key]
        public int LogId { get; set; }


        [Display(Name = "Exchange")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از{1} کاراکتر باشد")]
        public string Exchange { get; set; }


        [Display(Name = "Routing Key")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از{1} کاراکتر باشد")]
        public string Routing_Key { get; set; }


        public bool Redelivered { get; set; }


        [MinLength(5, ErrorMessage = " {0} حداقل باید {1} کاراکتر باشد")]
        [Display(Name = "Message")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از{1} کاراکتر باشد")]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
