using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;


namespace WebApplication1.Model
{
    public class CFContext : DbContext{
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public CFContext(DbContextOptions<CFContext> options) : base(options) { }

        public CFContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            if (!dbContextOptionsBuilder.IsConfigured) {
                dbContextOptionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18290;Integrated Security=True");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Patient>(e =>{
                e.HasKey(e => e.IdPatient).HasName("Patient_PK");
                e.Property(a => a.IdPatient).ValueGeneratedNever();
                e.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
                e.Property(a => a.LastName).HasMaxLength(100).IsRequired();
                e.Property(a => a.Birthdate).IsRequired();
            });
            modelBuilder.Entity<Doctor>(e => {
                e.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                e.Property(a => a.IdDoctor).ValueGeneratedNever();
                e.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
                e.Property(a => a.LastName).HasMaxLength(100).IsRequired();
                e.Property(a => a.Email).HasMaxLength(100).IsRequired();

            });
            modelBuilder.Entity<Medicament>(e => {
                e.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                e.Property(a => a.IdMedicament).ValueGeneratedNever();
                e.Property(a => a.Name).HasMaxLength(100).IsRequired();
                e.Property(a => a.Description).HasMaxLength(100).IsRequired();
                e.Property(a => a.Type).HasMaxLength(100).IsRequired();

            });
            modelBuilder.Entity<Prescription>(e =>{ 
                e.HasKey(e => e.IdPrescription).HasName("Prescritpion_PK");
                e.Property(a => a.IdPrescription).ValueGeneratedNever();
                e.Property(a => a.Date).IsRequired();
                e.Property(a => a.DueDate).IsRequired();
                e.HasOne(d => d.Patient).WithMany(f => f.Prescription).HasForeignKey(g => g.IdPatient).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Prescription_Patient");
                e.HasOne(d => d.Doctor).WithMany(f => f.Prescription).HasForeignKey(g => g.IdDoctor).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Prescription_Doctor");
            });
            modelBuilder.Entity<Prescription_Medicament>(e => {
                e.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("Prescription_Medicament_PK");
                e.Property(a => a.IdMedicament).ValueGeneratedNever();
                e.Property(a => a.IdPrescription).ValueGeneratedNever();
                e.Property(a => a.Dose).IsRequired();
                e.Property(a => a.Details).IsRequired();
                e.HasOne(d => d.Medicament).WithMany(f => f.Medicaments_Prescriptions).HasForeignKey(g => g.IdMedicament).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Prescription_Medicament_Medicament");
                e.HasOne(d => d.Prescription).WithMany(f => f.Prescription_Medicaments).HasForeignKey(g => g.IdPrescription).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Prescription_Medicament_Prescription");
            });
            modelBuilder.Entity<Patient>(e =>  {
                List<Patient> list = new List<Patient> {
                    new Patient{IdPatient = 0,FirstName = "aaa",LastName = "bbb", Birthdate = new DateTime(1993,1, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    new Patient{IdPatient = 1,FirstName = "ccc",LastName = "ddd", Birthdate = new DateTime(1993,1, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    new Patient{IdPatient = 2,FirstName = "eee",LastName = "fff", Birthdate = new DateTime(1993,1, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    new Patient{IdPatient = 3,FirstName = "ggg",LastName = "hhh", Birthdate = new DateTime(1993,1, 5, 0, 0, 0, 0, DateTimeKind.Local) }
                    };
                e.HasData(list);
            });
            modelBuilder.Entity<Medicament>(e => {
                List<Medicament> list = new List<Medicament> {
                    new Medicament{IdMedicament = 10,Name = "ITN",Description = "z ABPD", Type = "Dropsy" },
                    new Medicament{IdMedicament = 20,Name = "APBD",Description = " to ITN", Type = "Turbo dropsy" },
                    new Medicament{IdMedicament = 40,Name = "DTO",Description = "po co", Type = "Alkohol"}
                    };
                e.HasData(list);
            });
            modelBuilder.Entity<Doctor>(e => {
                List<Doctor> list = new List<Doctor> {
                    new Doctor{IdDoctor = 1,FirstName = "Jan",LastName = "Sobieski", Email = "0dot25l@gmail.com" },
                    new Doctor{IdDoctor = 2,FirstName = "Pan",LastName = "Tadeusz", Email = "0dot50l@gmail.com" },
                    };
                e.HasData(list);
            });
            modelBuilder.Entity<Prescription>(e => {
                List<Prescription> list = new List<Prescription> {
                    new Prescription{IdPrescription = 111,Date = DateTime.Today,DueDate =  new DateTime(2050, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), IdPatient = 0 ,IdDoctor = 1},
                    new Prescription{IdPrescription = 112,Date = DateTime.Today,DueDate = new DateTime(2050, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), IdPatient = 1,IdDoctor = 1},
                    new Prescription{IdPrescription = 113,Date = DateTime.Today,DueDate = new DateTime(2050, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), IdPatient = 2,IdDoctor = 1},
                    new Prescription{IdPrescription = 114,Date = DateTime.Today,DueDate = new DateTime(2050, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), IdPatient = 3,IdDoctor = 2}
                    };
                e.HasData(list);
            });
            modelBuilder.Entity<Prescription_Medicament>(e => {
                List<Prescription_Medicament> list = new List<Prescription_Medicament> {
                    new Prescription_Medicament{IdMedicament = 10,IdPrescription = 112,Dose  = 1 , Details  = "Przed cwiczeniami" } ,
                    new Prescription_Medicament{IdMedicament = 20,IdPrescription = 111,Dose  = 2 , Details  = "Przed egzaminem"},
                    new Prescription_Medicament{IdMedicament = 40,IdPrescription = 113,Dose  = 5, Details  = "Po wykładach"},
                    new Prescription_Medicament{IdMedicament = 40,IdPrescription = 114,Dose  = 200, Details  = "Przed APBD"}
                    };
                e.HasData(list);
            });

        }
    }
    }

