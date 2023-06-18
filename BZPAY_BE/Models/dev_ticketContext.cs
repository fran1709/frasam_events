using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BZPAY_BE.Models
{
    public partial class dev_ticketContext : DbContext
    {
        public dev_ticketContext()
        {
        }

        public dev_ticketContext(DbContextOptions<dev_ticketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asiento> Asientos { get; set; } 
        //public virtual DbSet<Aspnetrole> Aspnetroles { get; set; } 
        //public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; } 
        public virtual DbSet<AspnetUser> Aspnetusers { get; set; } 
       //public object AspnetUsers { get; internal set; }
        //public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; } 
       // public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; } 
       // public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; } 
        public virtual DbSet<Compra> Compras { get; set; } 
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Entrada> Entradas { get; set; }
        public virtual DbSet<Escenario> Escenarios { get; set; } 
        public virtual DbSet<Evento?> Eventos { get; set; }
        public virtual DbSet<TipoEscenario> TipoEscenarios { get; set; } 
        public virtual DbSet<TipoEvento> TipoEventos { get; set; } 
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=dev_ticket", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));
            }
        }
        
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<Aspnetuserlogin>().HasNoKey();
            // Other entity configurations
            modelBuilder.Entity<Aspnetusertoken>().HasNoKey();
            modelBuilder.Entity<Efmigrationshistory>().HasNoKey();

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("compra");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_spanish_ci");

                entity.HasIndex(e => e.IdCliente, "id_cliente");

                entity.HasIndex(e => e.IdEntrada, "id_entrada");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Created_By");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.FechaReserva)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_reserva");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_cliente");

                entity.Property(e => e.IdEntrada)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_entrada");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy).HasColumnType("int(11)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_1");

                entity.HasOne(d => d.IdEntradaNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_2");
            });

            modelBuilder.Entity<AspnetUser>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasMaxLength(6);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);


            });
            /*modelBuilder.Entity<Aspnetrole>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });*/

            /*modelBuilder.Entity<Aspnetroleclaim>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                //entity.HasOne(d => d.Role)
                ///    .WithMany(p => p.Aspnetroleclaims)
                 //   .HasForeignKey(d => d.RoleId)
                   // .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetuserclaim>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");


            });


            modelBuilder.Entity<Aspnetuserlogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

            });

            modelBuilder.Entity<Aspnetusertoken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);


            });*/

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.ToTable("entradas");

                entity.HasIndex(e => e.IdEvento, "id_evento");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Created_By");

                entity.Property(e => e.Disponibles).HasColumnType("int(11)");

                entity.Property(e => e.IdEvento)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_evento");

                entity.Property(e => e.Precio)
                    .HasPrecision(10)
                    .HasColumnName("precio");

                entity.Property(e => e.TipoAsiento)
                    .HasMaxLength(100)
                    .HasColumnName("tipo_asiento")
                    .UseCollation("utf8_spanish_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entradas_ibfk_1");
            });

            modelBuilder.Entity<Escenario>(entity =>
            {
                entity.ToTable("escenario");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Created_By");

                entity.Property(e => e.Localizacion)
                    .HasMaxLength(100)
                    .HasColumnName("localizacion")
                    .UseCollation("utf8_spanish_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre")
                    .UseCollation("utf8_spanish_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("evento");

                entity.HasIndex(e => e.IdEscenario, "id_escenario");

                entity.HasIndex(e => e.IdTipoEvento, "id_tipo_evento");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Created_By");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8_spanish_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Disponible)
                    .HasColumnType("int(11)")
                    .HasColumnName("disponible");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEscenario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_escenario");

                entity.Property(e => e.IdTipoEvento)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tipo_evento");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEscenarioNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdEscenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evento_ibfk_1");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evento_ibfk_2");
            });

            modelBuilder.Entity<TipoEscenario>(entity =>
            {
                entity.ToTable("tipo_escenario");

                entity.HasIndex(e => e.IdEscenario, "id_escenario");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Created_By");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8_spanish_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdEscenario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_escenario");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Updated_By");

                entity.HasOne(d => d.IdEscenarioNavigation)
                    .WithMany(p => p.TipoEscenarios)
                    .HasForeignKey(d => d.IdEscenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tipo_escenario_ibfk_1");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.ToTable("tipo_evento");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Created_By");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion")
                    .UseCollation("utf8_spanish_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("Updated_By");
            });

           
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        /*
      protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.UseCollation("utf8mb4_general_ci")
               .HasCharSet("utf8mb4");

           modelBuilder.Entity<Asiento>(entity =>
           {
               entity.ToTable("asiento");

               entity.HasComment("tipos de asiento del escenario");

               entity.HasIndex(e => e.IdEscenario, "id_escenario");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.Cantidad)
                   .HasColumnType("int(11)")
                   .HasColumnName("cantidad");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Descripcion)
                   .HasMaxLength(100)
                   .HasColumnName("descripcion")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.IdEscenario)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_escenario");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");

               entity.HasOne(d => d.IdEscenarioNavigation)
                   .WithMany(p => p.Asientos)
                   .HasForeignKey(d => d.IdEscenario)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("asiento_ibfk_1");
           });

           modelBuilder.Entity<Aspnetrole>(entity =>
           {
               entity.ToTable("aspnetroles");

               entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                   .IsUnique();

               entity.Property(e => e.Name).HasMaxLength(256);

               entity.Property(e => e.NormalizedName).HasMaxLength(256);
           });

           modelBuilder.Entity<Aspnetroleclaim>(entity =>
           {
               entity.ToTable("aspnetroleclaims");

               entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

               entity.Property(e => e.Id).HasColumnType("int(11)");

               entity.HasOne(d => d.Role)
                   .WithMany(p => p.Aspnetroleclaims)
                   .HasForeignKey(d => d.RoleId)
                   .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
           });

           modelBuilder.Entity<AspnetUser>(entity =>
           {
               entity.ToTable("aspnetusers");

               entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

               entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                   .IsUnique();

               entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

               entity.Property(e => e.Email).HasMaxLength(256);

               entity.Property(e => e.LockoutEnd).HasMaxLength(6);

               entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

               entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

               entity.Property(e => e.UserName).HasMaxLength(256);

               
           });

           modelBuilder.Entity<Aspnetuserclaim>(entity =>
           {
               entity.ToTable("aspnetuserclaims");

               entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

               entity.Property(e => e.Id).HasColumnType("int(11)");

              
           });

            
           modelBuilder.Entity<Aspnetuserlogin>(entity =>
           {
               entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                   .HasName("PRIMARY")
                   .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

               entity.ToTable("aspnetuserlogins");

               entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

               entity.Property(e => e.LoginProvider).HasMaxLength(128);

               entity.Property(e => e.ProviderKey).HasMaxLength(128);

           });

           modelBuilder.Entity<Aspnetusertoken>(entity =>
           {
               entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                   .HasName("PRIMARY")
                   .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

               entity.ToTable("aspnetusertokens");

               entity.Property(e => e.LoginProvider).HasMaxLength(128);

               entity.Property(e => e.Name).HasMaxLength(128);

          
           });

           modelBuilder.Entity<Compra>(entity =>
           {
               entity.ToTable("compra");

               entity.HasCharSet("utf8")
                   .UseCollation("utf8_spanish_ci");

               entity.HasIndex(e => e.IdCliente, "id_cliente");

               entity.HasIndex(e => e.IdEntrada, "id_entrada");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.Active).HasColumnType("int(11)");

               entity.Property(e => e.Cantidad)
                   .HasColumnType("int(11)")
                   .HasColumnName("cantidad");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.FechaPago)
                   .HasColumnType("datetime")
                   .HasColumnName("fecha_pago");

               entity.Property(e => e.FechaReserva)
                   .HasColumnType("datetime")
                   .HasColumnName("fecha_reserva");

               entity.Property(e => e.IdCliente)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_cliente");

               entity.Property(e => e.IdEntrada)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_entrada");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy).HasColumnType("int(11)");

               entity.HasOne(d => d.IdClienteNavigation)
                   .WithMany(p => p.Compras)
                   .HasForeignKey(d => d.IdCliente)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("compra_ibfk_1");

               entity.HasOne(d => d.IdEntradaNavigation)
                   .WithMany(p => p.Compras)
                   .HasForeignKey(d => d.IdEntrada)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("compra_ibfk_2");
           });

           modelBuilder.Entity<Efmigrationshistory>(entity =>
           {
               entity.HasKey(e => e.MigrationId)
                   .HasName("PRIMARY");

               entity.ToTable("__efmigrationshistory");

               entity.Property(e => e.MigrationId).HasMaxLength(150);

               entity.Property(e => e.ProductVersion).HasMaxLength(32);
           });

           modelBuilder.Entity<Entrada>(entity =>
           {
               entity.ToTable("entradas");

               entity.HasIndex(e => e.IdEvento, "id_evento");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Disponibles).HasColumnType("int(11)");

               entity.Property(e => e.IdEvento)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_evento");

               entity.Property(e => e.Precio)
                   .HasPrecision(10)
                   .HasColumnName("precio");

               entity.Property(e => e.TipoAsiento)
                   .HasMaxLength(100)
                   .HasColumnName("tipo_asiento")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");

               entity.HasOne(d => d.IdEventoNavigation)
                   .WithMany(p => p.Entrada)
                   .HasForeignKey(d => d.IdEvento)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("entradas_ibfk_1");
           });

           modelBuilder.Entity<Escenario>(entity =>
           {
               entity.ToTable("escenario");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Localizacion)
                   .HasMaxLength(100)
                   .HasColumnName("localizacion")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.Nombre)
                   .HasMaxLength(100)
                   .HasColumnName("nombre")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");
           });

           modelBuilder.Entity<Evento>(entity =>
           {
               entity.ToTable("evento");

               entity.HasIndex(e => e.IdEscenario, "id_escenario");

               entity.HasIndex(e => e.IdTipoEvento, "id_tipo_evento");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Descripcion)
                   .HasMaxLength(100)
                   .HasColumnName("descripcion")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.Disponible)
                   .HasColumnType("int(11)")
                   .HasColumnName("disponible");

               entity.Property(e => e.Fecha)
                   .HasColumnType("datetime")
                   .HasColumnName("fecha");

               entity.Property(e => e.IdEscenario)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_escenario");

               entity.Property(e => e.IdTipoEvento)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_tipo_evento");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");

               entity.HasOne(d => d.IdEscenarioNavigation)
                   .WithMany(p => p.Eventos)
                   .HasForeignKey(d => d.IdEscenario)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("evento_ibfk_1");

               entity.HasOne(d => d.IdTipoEventoNavigation)
                   .WithMany(p => p.Eventos)
                   .HasForeignKey(d => d.IdTipoEvento)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("evento_ibfk_2");
           });

           modelBuilder.Entity<TipoEscenario>(entity =>
           {
               entity.ToTable("tipo_escenario");

               entity.HasIndex(e => e.IdEscenario, "id_escenario");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Descripcion)
                   .HasMaxLength(100)
                   .HasColumnName("descripcion")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.IdEscenario)
                   .HasColumnType("int(11)")
                   .HasColumnName("id_escenario");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");

               entity.HasOne(d => d.IdEscenarioNavigation)
                   .WithMany(p => p.TipoEscenarios)
                   .HasForeignKey(d => d.IdEscenario)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("tipo_escenario_ibfk_1");
           });

           modelBuilder.Entity<TipoEvento>(entity =>
           {
               entity.ToTable("tipo_evento");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .HasColumnName("id");

               entity.Property(e => e.Active).HasColumnType("int(11)");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Descripcion)
                   .HasMaxLength(100)
                   .HasColumnName("descripcion")
                   .UseCollation("utf8_spanish_ci")
                   .HasCharSet("utf8");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");
           });

           modelBuilder.Entity<Usuario>(entity =>
           {
               entity.ToTable("usuario");

               entity.HasCharSet("utf8")
                   .UseCollation("utf8_spanish_ci");

               entity.Property(e => e.Id)
                   .HasColumnType("int(11)")
                   .ValueGeneratedNever()
                   .HasColumnName("id");

               entity.Property(e => e.Correo)
                   .HasMaxLength(100)
                   .HasColumnName("correo");

               entity.Property(e => e.CreatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Created_At")
                   .HasDefaultValueSql("current_timestamp()");

               entity.Property(e => e.CreatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Created_By");

               entity.Property(e => e.Nombre)
                   .HasMaxLength(100)
                   .HasColumnName("nombre");

               entity.Property(e => e.Rol)
                   .HasColumnType("int(11)")
                   .HasColumnName("rol");

               entity.Property(e => e.Telefono)
                   .HasColumnType("int(11)")
                   .HasColumnName("telefono");

               entity.Property(e => e.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasColumnName("Updated_At");

               entity.Property(e => e.UpdatedBy)
                   .HasColumnType("int(11)")
                   .HasColumnName("Updated_By");
           });

           OnModelCreatingPartial(modelBuilder);*/
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
       