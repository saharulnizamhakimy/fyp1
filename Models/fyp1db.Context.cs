﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fyp1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fyp1dbEntities : DbContext
    {
        public fyp1dbEntities()
            : base("name=fyp1dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_acadprog> tb_acadprog { get; set; }
        public virtual DbSet<tb_committee> tb_committee { get; set; }
        public virtual DbSet<tb_domain> tb_domain { get; set; }
        public virtual DbSet<tb_proposal> tb_proposal { get; set; }
        public virtual DbSet<tb_status> tb_status { get; set; }
        public virtual DbSet<tb_student> tb_student { get; set; }
        public virtual DbSet<tb_sv> tb_sv { get; set; }
        public virtual DbSet<tb_user> tb_user { get; set; }
        public virtual DbSet<tb_usertype> tb_usertype { get; set; }
    }
}
