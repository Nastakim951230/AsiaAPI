﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asia.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AsiaDrama_TrifonovaEntities : DbContext
    {
        public AsiaDrama_TrifonovaEntities()
            : base("name=AsiaDrama_TrifonovaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<KinoAndActor> KinoAndActor { get; set; }
        public virtual DbSet<KinoAndGenre> KinoAndGenre { get; set; }
        public virtual DbSet<KinoAndGroups> KinoAndGroups { get; set; }
        public virtual DbSet<KinoAndSerial> KinoAndSerial { get; set; }
        public virtual DbSet<Sentence> Sentence { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
