using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Proyecto_Final_BD_POO_2021Context : DbContext
    {
        public Proyecto_Final_BD_POO_2021Context()
        {
        }

        public Proyecto_Final_BD_POO_2021Context(DbContextOptions<Proyecto_Final_BD_POO_2021Context> options)
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
                optionsBuilder.UseSqlServer("Server=LAPTOP-00OSCEQ3;Database=Proyecto_Final_BD_POO_2021;Trusted_Connection=True");
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

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.DuiCitizen)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui_citizen");

                entity.Property(e => e.IdVaccination).HasColumnName("id_vaccination");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__dui_c__4BAC3F29");

                entity.HasOne(d => d.IdVaccinationNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdVaccination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_va__4CA06362");
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
                    .HasConstraintName("FK__BOOTH__id_manage__44FF419A");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__CITIZEN__D876F1BE0DC0B70B");

                entity.ToTable("CITIZEN");

                entity.HasIndex(e => e.EMail, "UQ__CITIZEN__31660442BCDA502A")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__CITIZEN__B43B145F4C1696B5")
                    .IsUnique();

                entity.Property(e => e.Dui)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direction");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_mail");

                entity.Property(e => e.IdAdministrator)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("id_administrator");

                entity.Property(e => e.IdDisease).HasColumnName("id_disease");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_admi__48CFD27E");

                entity.HasOne(d => d.IdDiseaseNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdDisease)
                    .HasConstraintName("FK__CITIZEN__id_dise__49C3F6B7");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_inst__4AB81AF0");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("DISEASE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Disease1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("disease");
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

                entity.HasIndex(e => e.EMailInstitutional, "UQ__EMPLOYEE__510293D1817622D7")
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
                    .HasConstraintName("FK__EMPLOYEE__id_adm__47DBAE45");

                entity.HasOne(d => d.IdBoothNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdBooth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_boo__45F365D3");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_typ__46E78A0C");
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

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
                    .HasConstraintName("FK__LOGIN__id_booth__440B1D61");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOGIN__id_employ__4316F928");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("MANAGER");

                entity.HasIndex(e => e.EMail, "UQ__MANAGER__3166044240FB92ED")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__MANAGER__B43B145F37A6C0FD")
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

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateTimeApplication)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time_application");

                entity.Property(e => e.DateTimeProcess)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time_process");

                entity.Property(e => e.IdEffectSecondary).HasColumnName("id_effect_secondary");

                entity.Property(e => e.IdPlaceVaccination).HasColumnName("id_place_vaccination");

                entity.Property(e => e.TimeSecondaryEffect)
                    .HasColumnType("datetime")
                    .HasColumnName("time_secondary_effect");

                entity.HasOne(d => d.IdEffectSecondaryNavigation)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.IdEffectSecondary)
                    .HasConstraintName("FK__VACCINATI__id_ef__4D94879B");

                entity.HasOne(d => d.IdPlaceVaccinationNavigation)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.IdPlaceVaccination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VACCINATI__id_pl__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
