using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace work_1.Models
{
    public partial class Product
    {

        [Key]
        public int ProductsId { get; set; }
        [Display(Name = "Products Name "), Required]
        public string ProductsName { get; set; }


        public virtual ICollection<OrderEntry> OrderEntries { get; set; }
    }
    public partial class OrderEntry
    {
        [Key]

        public int OrderEntriesId { get; set; }
        [Display(Name = "Customers"), Required]
        public int CustomersId { get; set; }
        [Display(Name = "Products"), Required]

        public int ProductsId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }


    }

    public partial class Customer
    {
        [Key]
        public int CustomersId { get; set; }
        [Display(Name = "Customers Name "), Required]
        public string CustomersName { get; set; }
        [Display(Name = "Payment Date"), Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public System.DateTime PaymentDate { get; set; }

        [Display(Name = "Dress Size")]
        public int CustomerSize { get; set; }
        public string Picture { get; set; }
        public bool UrgentDelivery { get; set; }
        public virtual ICollection<OrderEntry> OrderEntries { get; set; }
    }
    public partial class FashionDbContext : DbContext
    {
        public FashionDbContext() : base("name=FashionDbContext")
        { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderEntry> OrderEntries { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }


}


