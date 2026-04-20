using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;




namespace work_1.Models.ViewModels
{
    public class CustomerVM
    {
       

        public int CustomersId { get; set; }
        [Display(Name = "Customers Name "), Required]
        public string CustomersName { get; set; }
        [Display(Name = "Payment Date"), Required, Column(TypeName = "data"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public System.DateTime PaymentDate { get; set; }
        [Display(Name = "Dress Size")]
        public int CustomerSize { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase PictureFile { get; set; }
        [Display(Name = "Urgent Delivery ")]
        public bool UrgentDelivery { get; set; }

       
        public virtual ICollection<OrderEntry> OrderEntries { get; set; }
        public List<int> ProductList { get; set; } = new List<int>();
    }
}

    
