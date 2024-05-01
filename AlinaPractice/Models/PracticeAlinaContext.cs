using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlinaPractice.Models;

public partial class PracticeAlinaContext : DbContext
{
    public PracticeAlinaContext()
    {
    }

    public PracticeAlinaContext(DbContextOptions<PracticeAlinaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Availability> Availabilities { get; set; }

    public virtual DbSet<BatchNumber> BatchNumbers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DeliveryStaff> DeliveryStaffs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Inn> Inns { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Medicament> Medicaments { get; set; }

    public virtual DbSet<MethodsOfApplication> MethodsOfApplications { get; set; }

    public virtual DbSet<Okpd> Okpds { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<ReleaseForm> ReleaseForms { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Technic> Technics { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<TypeOfHealthcareInstitution> TypeOfHealthcareInstitutions { get; set; }

    public virtual DbSet<TypeOfPackaging> TypeOfPackagings { get; set; }

    public virtual DbSet<TypeOperation> TypeOperations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("server=localhost;user id=postgres;password=1234;Database =PracticeAlina");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("Accounts_pkey");

            entity.Property(e => e.IdUser)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(4L, null, null, null, null, null)
                .HasColumnName("ID_User");
            entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");
            entity.Property(e => e.IdPost).HasColumnName("ID_Post");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("123123");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdPost)
                .HasConstraintName("asda");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.IdApplications).HasName("Applications_pkey");

            entity.ToTable(tb => tb.HasComment("Заявки"));

            entity.Property(e => e.IdApplications)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Applications");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.IdMedicament).HasColumnName("ID_Medicament");

            entity.HasOne(d => d.IdMedicamentNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Applications_ID_Medicament_fkey");
        });

        modelBuilder.Entity<Availability>(entity =>
        {
            entity.HasKey(e => e.IdAvailability).HasName("Availability_pkey");

            entity.ToTable("Availability", tb => tb.HasComment("Наличие"));

            entity.Property(e => e.IdAvailability)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Availability");
            entity.Property(e => e.IdBatchNumber).HasColumnName("ID_BatchNumber");
            entity.Property(e => e.IdMedicament).HasColumnName("ID_Medicament");

            entity.HasOne(d => d.IdBatchNumberNavigation).WithMany(p => p.Availabilities)
                .HasForeignKey(d => d.IdBatchNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Availability_ID_BatchNumber_fkey");

            entity.HasOne(d => d.IdMedicamentNavigation).WithMany(p => p.Availabilities)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Availability_ID_Medicament_fkey");
        });

        modelBuilder.Entity<BatchNumber>(entity =>
        {
            entity.HasKey(e => e.IdBatchNumber).HasName("Batch number_pkey");

            entity.ToTable("Batch number", tb => tb.HasComment("Номер партии"));

            entity.Property(e => e.IdBatchNumber)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_BatchNumber");
            entity.Property(e => e.DExpiration).HasColumnName("D_expiration ");
            entity.Property(e => e.DProduction).HasColumnName("D_production");
            entity.Property(e => e.DReceipt).HasColumnName("D_receipt");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("Client_pkey");

            entity.ToTable("Client", tb => tb.HasComment("Клиенты"));

            entity.Property(e => e.IdClient)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Client");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.Email).HasColumnType("character varying");
            entity.Property(e => e.IdTypeHealthcare).HasColumnName("ID_TypeHealthcare");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Patronymic).HasColumnType("character varying");
            entity.Property(e => e.Surname).HasColumnType("character varying");

            entity.HasOne(d => d.IdTypeHealthcareNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdTypeHealthcare)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_ID_TypeHealthcare_fkey");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.IdDelivery).HasName("Delivery_pkey");

            entity.ToTable("Delivery", tb => tb.HasComment("Доставка"));

            entity.Property(e => e.IdDelivery)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Delivery");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.IdDeliveryStaff).HasColumnName("ID_DeliveryStaff");
            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.IdTechnic).HasColumnName("ID_Technic");
            entity.Property(e => e.IdTranspost).HasColumnName("ID_Transpost");

            entity.HasOne(d => d.IdDeliveryStaffNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdDeliveryStaff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Delivery_ID_DeliveryStaff_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Delivery_ID_Status_fkey");

            entity.HasOne(d => d.IdTechnicNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdTechnic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Delivery_ID_Technic_fkey");

            entity.HasOne(d => d.IdTranspostNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdTranspost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Delivery_ID_Transpost_fkey");
        });

        modelBuilder.Entity<DeliveryStaff>(entity =>
        {
            entity.HasKey(e => e.IdDeliveryStaff).HasName("Delivery staff_pkey");

            entity.ToTable("Delivery staff");

            entity.Property(e => e.IdDeliveryStaff)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_DeliveryStaff");

            entity.HasOne(d => d.DriverNavigation).WithMany(p => p.DeliveryStaffDriverNavigations)
                .HasForeignKey(d => d.Driver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Delivery staff_Driver_fkey");

            entity.HasOne(d => d.LogisticsNavigation).WithMany(p => p.DeliveryStaffLogisticsNavigations)
                .HasForeignKey(d => d.Logistics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Delivery staff_Logistics_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartment).HasName("Department_pkey");

            entity.ToTable("Department", tb => tb.HasComment("Отделы"));

            entity.Property(e => e.IdDepartment)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Department");
            entity.Property(e => e.Appellation).HasColumnType("character varying");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("Employee_pkey");

            entity.ToTable("Employee", tb => tb.HasComment("Сотрудники"));

            entity.Property(e => e.IdEmployee)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Employee");
            entity.Property(e => e.DEmployment).HasColumnName("D_Employment");
            entity.Property(e => e.IdPost).HasColumnName("ID_Post");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Passport).HasMaxLength(12);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_ID_Post_fkey");
        });

        modelBuilder.Entity<Inn>(entity =>
        {
            entity.HasKey(e => e.IdInn).HasName("INN_pkey");

            entity.ToTable("INN", tb => tb.HasComment("INN - international nonproprietary name\nМНН - международное непатентованное наименование"));

            entity.Property(e => e.IdInn)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_INN");
            entity.Property(e => e.Appellation).HasMaxLength(100);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer).HasName("Manufacturer_pkey");

            entity.ToTable("Manufacturer", tb => tb.HasComment("Производитель"));

            entity.Property(e => e.IdManufacturer)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Manufacturer");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Appellation).HasMaxLength(100);
            entity.Property(e => e.Email).HasColumnType("character varying");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .HasColumnName("M_Name");
            entity.Property(e => e.MPatronymic)
                .HasMaxLength(50)
                .HasColumnName("M_Patronymic");
            entity.Property(e => e.MSurname)
                .HasMaxLength(50)
                .HasColumnName("M_Surname ");
        });

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => e.IdMedicament).HasName("Medicament_pkey");

            entity.ToTable("Medicament", tb => tb.HasComment("Препараты"));

            entity.Property(e => e.IdMedicament)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Medicament");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Dosage).HasMaxLength(10);
            entity.Property(e => e.IdBatchNumber).HasColumnName("ID_BatchNumber");
            entity.Property(e => e.IdInn).HasColumnName("ID_INN");
            entity.Property(e => e.IdManufacturer).HasColumnName("ID_Manufacturer");
            entity.Property(e => e.IdMethodsOfApplication).HasColumnName("ID_MethodsOfApplication");
            entity.Property(e => e.IdOkpd2).HasColumnName("ID_OKPD2");
            entity.Property(e => e.IdReleaseForm).HasColumnName("ID_ReleaseForm");
            entity.Property(e => e.IdTypeOfPackaging).HasColumnName("ID_TypeOfPackaging");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("money")
                .HasColumnName("Purchase_price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(10)
                .HasColumnName("Quantity ");
            entity.Property(e => e.TradeName)
                .HasMaxLength(50)
                .HasColumnName("Trade_Name");

            entity.HasOne(d => d.IdBatchNumberNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdBatchNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_BatchNumber_fkey");

            entity.HasOne(d => d.IdInnNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdInn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_INN_fkey");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_Manufacturer_fkey");

            entity.HasOne(d => d.IdMethodsOfApplicationNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdMethodsOfApplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_MethodsOfApplication_fkey");

            entity.HasOne(d => d.IdOkpd2Navigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdOkpd2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_OKPD2_fkey");

            entity.HasOne(d => d.IdReleaseFormNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdReleaseForm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_ReleaseForm_fkey");

            entity.HasOne(d => d.IdTypeOfPackagingNavigation).WithMany(p => p.Medicaments)
                .HasForeignKey(d => d.IdTypeOfPackaging)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_ID_TypeOfPackaging_fkey");
        });

        modelBuilder.Entity<MethodsOfApplication>(entity =>
        {
            entity.HasKey(e => e.IdMethodsOfApplication).HasName("Methods of application_pkey");

            entity.ToTable("Methods of application", tb => tb.HasComment("Способы применения"));

            entity.Property(e => e.IdMethodsOfApplication)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_MethodsOfApplication");
            entity.Property(e => e.Appellation).HasColumnType("character varying");
        });

        modelBuilder.Entity<Okpd>(entity =>
        {
            entity.HasKey(e => e.IdOkpd2).HasName("OKPD_pkey");

            entity.ToTable("OKPD", tb => tb.HasComment("Код ОКПД 2"));

            entity.Property(e => e.IdOkpd2)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_OKPD2");
            entity.Property(e => e.Appellation).HasMaxLength(100);
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.IdOperations).HasName("Operations_pkey");

            entity.ToTable(tb => tb.HasComment("Складские операции"));

            entity.Property(e => e.IdOperations)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Operations");
            entity.Property(e => e.IdMedicament).HasColumnName("ID_Medicament");
            entity.Property(e => e.IdTypeOperations).HasColumnName("ID_TypeOperations");

            entity.HasOne(d => d.IdMedicamentNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Operations_ID_Medicament_fkey");

            entity.HasOne(d => d.IdTypeOperationsNavigation).WithMany(p => p.Operations)
                .HasForeignKey(d => d.IdTypeOperations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Operations_ID_TypeOperations_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("Order_pkey");

            entity.ToTable("Order", tb => tb.HasComment("Заказы"));

            entity.Property(e => e.IdOrder)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Order");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.IdApplications).HasColumnName("ID_Applications");
            entity.Property(e => e.IdClient).HasColumnName("ID_Client");
            entity.Property(e => e.IdDelivery).HasColumnName("ID_Delivery");
            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

            entity.HasOne(d => d.IdApplicationsNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_ID_Applications_fkey");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_ID_Client_fkey");

            entity.HasOne(d => d.IdDeliveryNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdDelivery)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_ID_Delivery_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_ID_Status_fkey");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("Post_pkey");

            entity.ToTable("Post", tb => tb.HasComment("Должности"));

            entity.Property(e => e.IdPost)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Post");
            entity.Property(e => e.Appellation).HasColumnType("character varying");
            entity.Property(e => e.IdDepartment).HasColumnName("ID_Department");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("Post_ID_Department_fkey");
        });

        modelBuilder.Entity<ReleaseForm>(entity =>
        {
            entity.HasKey(e => e.IdReleaseForm).HasName("Release form_pkey");

            entity.ToTable("Release form", tb => tb.HasComment("Форма выпуска"));

            entity.Property(e => e.IdReleaseForm)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_ReleaseForm");
            entity.Property(e => e.Appellation).HasMaxLength(100);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("Status_pkey");

            entity.ToTable("Status", tb => tb.HasComment("Статус\n"));

            entity.Property(e => e.IdStatus)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Status");
            entity.Property(e => e.Appellation).HasMaxLength(15);
        });

        modelBuilder.Entity<Technic>(entity =>
        {
            entity.HasKey(e => e.IdTechnic).HasName("Technic_pkey");

            entity.ToTable("Technic", tb => tb.HasComment("Техника"));

            entity.Property(e => e.IdTechnic)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Technic");
            entity.Property(e => e.Appellation).HasMaxLength(100);
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.IdTransport).HasName("Transport_pkey");

            entity.ToTable("Transport", tb => tb.HasComment("Транспорт"));

            entity.Property(e => e.IdTransport)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_Transport");
            entity.Property(e => e.Appellation).HasMaxLength(100);
            entity.Property(e => e.Vin)
                .HasMaxLength(18)
                .HasColumnName("VIN");
        });

        modelBuilder.Entity<TypeOfHealthcareInstitution>(entity =>
        {
            entity.HasKey(e => e.IdTypeHealthcare).HasName("Type of healthcare institution_pkey");

            entity.ToTable("Type of healthcare institution", tb => tb.HasComment("Вид учреждения здравоохранения"));

            entity.Property(e => e.IdTypeHealthcare)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_TypeHealthcare ");
            entity.Property(e => e.Appellation).HasMaxLength(30);
        });

        modelBuilder.Entity<TypeOfPackaging>(entity =>
        {
            entity.HasKey(e => e.IdTypeOfPackaging).HasName("Type of packaging_pkey");

            entity.ToTable("Type of packaging", tb => tb.HasComment("Вид упаковки"));

            entity.Property(e => e.IdTypeOfPackaging)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_TypeOfPackaging");
            entity.Property(e => e.Appellation).HasColumnType("character varying");
        });

        modelBuilder.Entity<TypeOperation>(entity =>
        {
            entity.HasKey(e => e.IdTypeOperations).HasName("Type operations_pkey");

            entity.ToTable("Type operations", tb => tb.HasComment("Тип складской операции"));

            entity.Property(e => e.IdTypeOperations)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID_TypeOperations");
            entity.Property(e => e.Appellation).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
