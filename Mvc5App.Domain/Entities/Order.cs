using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc5App.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [DisplayName("№")]
        [Required]
        public string Number { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Shipping { get; set; }

        public Manager Manager { get; set; }
        public string Annotation { get; set; }
    }
}
