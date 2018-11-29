using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc5App.Domain.Entities
{
    public class Manager
    {
        public int ManagerId { get; set; }

        [DisplayName("Manager")]
        [Required(ErrorMessage = "Please choose a manager")]
        public string Name { get; set; }
    }
}
