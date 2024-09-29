using System.ComponentModel.DataAnnotations;

namespace PetProjectC_NeuroWeb.Modules.BasketModule.Core
{
    public class UserBasket
    {
        [Key]
        public string PersonId { get; set; }
        public List<string> ProductId { get; set; }
        //public virtual Product Product { get; set; }


    }
}
