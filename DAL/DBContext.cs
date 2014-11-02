using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Oblig1.DAL
{
    public class Users
    {
        [Key]

        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Phonenr { get; set; }
        public string Password { get; set; }
        public virtual Cities cities { get; set; }
        public virtual List<Orders> Orders { get; set; }
    }

    public class dbUsers
    {
        [Key]
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }

    public class Cities
    {
        [Key]
        [Required(ErrorMessage = "Postcode must be added")]
        [StringLength(4, ErrorMessage = "Postcode must be 4 characters")]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "City must be added")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters in city")]
        public string Cityname { get; set; }
    }

    public class Orders
    {
        [Key]
        public int Orderid { get; set; }
        public int Orderprice { get; set; }
       // public virtual Users users { get; set; }
        public virtual List<OrderLines> Orderlines { get; set; }
    }

    public class OrderLines
    {
        [Key]
        public int Orderlineid { get; set; }
        public int Itemamount { get; set; }
        public virtual Items Items { get; set; }

    }

    public class Carts
    {
        [Key]
        public int Cartid { get; set; }
        public string Remember { get; set; }
        public int Itemid { get; set; }
        public int Count { get; set; }
        public virtual Items Items { get; set; }

    }

    public class Items
    {
        [Key]
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public int Itemprice { get; set; }
        public int Currentstock { get; set; }
        public string Itemtype { get; set; }
        public string PictureURL { get; set; }
    }

    public class PastaContext : DbContext
    {

        public PastaContext()
            : base("name=PastaModel")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<dbUsers> dbUsers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}