﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab_9_MVC.Models;

namespace Lab_9_MVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentBusEntities : DbContext
    {
        public RentBusEntities()
            : base("name=RentBusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Order> Order { get; set; }
    }
}
