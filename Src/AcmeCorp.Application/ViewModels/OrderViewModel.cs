using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AcmeCorp.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Customer Id is Required")]
        [DisplayName("CustomerId")]
        public Guid CustomerId { get; set; }
    }
}
