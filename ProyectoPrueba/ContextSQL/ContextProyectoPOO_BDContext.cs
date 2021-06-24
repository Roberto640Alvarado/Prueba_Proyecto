using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class ContextProyectoPOO_BDContext : DbContext
    {
        public ContextProyectoPOO_BDContext()
        {
        }

        public ContextProyectoPOO_BDContext(DbContextOptions<ContextProyectoPOO_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Booth> Booths { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<EffectSecondary> EffectSecondaries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<PlaceVaccination> PlaceVaccinations { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-00OSCEQ3;Database=ContextProyectoPOO_BD;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("ADMINISTRATOR");

                entity.Property(e => e.Id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.NameUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_user");

                entity.Property(e => e.PasswordUser)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password_user");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.IdCitizen).HasColumnName("id_citizen");

                entity.Property(e => e.IdVaccination).HasColumnName("id_vaccination");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_ci__48CFD27E");

                entity.HasOne(d => d.IdVaccinationNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdVaccination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_va__49C3F6B7");
            });

            modelBuilder.Entity<Booth>(entity =>
            {
                entity.ToTable("BOOTH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.IdManager)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id_manager");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.Booths)
                    .HasForeignKey(d => d.IdManager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOOTH__id_manage__4222D4EF");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("CITIZEN");

                entity.HasIndex(e => e.EMail, "UQ__CITIZEN__3166044227B0CF18")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__CITIZEN__B43B145F9BB49493")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_mail");

                entity.Property(e => e.IdAdministrator)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id_administrator");

                entity.Property(e => e.IdInstitution).HasColumnName("id_institution");

                entity.Property(e => e.NameCitizen)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name_citizen");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAdministratorNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdAdministrator)
                    .HasConstraintName("FK__CITIZEN__id_admi__45F365D3");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_inst__47DBAE45");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("DISEASE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disease1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("disease");

                entity.Property(e => e.IdCitizen).HasColumnName("id_citizen");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Diseases)
                    .HasForeignKey(d => d.IdCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DISEASE__id_citi__46E78A0C");
            });

            modelBuilder.Entity<EffectSecondary>(entity =>
            {
                entity.ToTable("EFFECT_SECONDARY");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EffectSecondary1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("effect_secondary");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.EMailInstitutional, "UQ__EMPLOYEE__510293D1FC848CFD")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.EMailInstitutional)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("E_mail_institutional");

                entity.Property(e => e.IdAdministrator)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id_administrator");

                entity.Property(e => e.IdBooth).HasColumnName("id_booth");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.NameEmployee)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_employee");

                entity.HasOne(d => d.IdAdministratorNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdAdministrator)
                    .HasConstraintName("FK__EMPLOYEE__id_adm__44FF419A");

                entity.HasOne(d => d.IdBoothNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdBooth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_boo__4316F928");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_typ__440B1D61");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("INSTITUTION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Institution1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.IdBooth).HasColumnName("id_booth");

                entity.Property(e => e.IdEmployee)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id_employee");

                entity.HasOne(d => d.IdBoothNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdBooth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOGIN__id_booth__412EB0B6");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOGIN__id_employ__403A8C7D");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("MANAGER");

                entity.HasIndex(e => e.EMail, "UQ__MANAGER__316604422D8002D3")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__MANAGER__B43B145F09D5D192")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("E_mail");

                entity.Property(e => e.NameManager)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_manager");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PlaceVaccination>(entity =>
            {
                entity.ToTable("PLACE_VACCINATION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PlaceVaccination1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("place_vaccination");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("TYPE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Type1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.ToTable("VACCINATION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTimeApplication)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time_application");

                entity.Property(e => e.DateTimeProcess)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time_process");

                entity.Property(e => e.IdEffectSecondary).HasColumnName("id_effect_secondary");

                entity.Property(e => e.IdPlaceVaccination).HasColumnName("id_place_vaccination");

                entity.Property(e => e.TimeSecondaryEffect)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("time_secondary_effect");

                entity.HasOne(d => d.IdEffectSecondaryNavigation)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.IdEffectSecondary)
                    .HasConstraintName("FK__VACCINATI__id_ef__4AB81AF0");

                entity.HasOne(d => d.IdPlaceVaccinationNavigation)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.IdPlaceVaccination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VACCINATI__id_pl__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
