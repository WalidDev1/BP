﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet_Transport.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TransportBDEntities3 : DbContext
    {
        public TransportBDEntities3()
            : base("name=TransportBDEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<societe> societes { get; set; }
        public virtual DbSet<trajet> trajets { get; set; }
        public virtual DbSet<ville> villes { get; set; }
    }
}
