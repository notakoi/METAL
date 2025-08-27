using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace generators.MIMICIV;

public partial class Mimic4Context : DbContext
{
    public Mimic4Context()
    {
    }

    public Mimic4Context(DbContextOptions<Mimic4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admission> Admissions { get; set; }

    public virtual DbSet<Caregiver> Caregivers { get; set; }

    public virtual DbSet<Chartevent> Chartevents { get; set; }

    public virtual DbSet<CollectionDisease> CollectionDiseases { get; set; }

    public virtual DbSet<DHcpc> DHcpcs { get; set; }

    public virtual DbSet<DIcdDiagnosis> DIcdDiagnoses { get; set; }

    public virtual DbSet<DIcdProcedure> DIcdProcedures { get; set; }

    public virtual DbSet<DItem> DItems { get; set; }

    public virtual DbSet<DLabitem> DLabitems { get; set; }

    public virtual DbSet<Datetimeevent> Datetimeevents { get; set; }

    public virtual DbSet<DiagnosesIcd> DiagnosesIcds { get; set; }

    public virtual DbSet<Drgcode> Drgcodes { get; set; }

    public virtual DbSet<Emar> Emars { get; set; }

    public virtual DbSet<EmarDetail> EmarDetails { get; set; }


    public virtual DbSet<Hcpcsevent> Hcpcsevents { get; set; }

    public virtual DbSet<Icustay> Icustays { get; set; }

    public virtual DbSet<Ingredientevent> Ingredientevents { get; set; }

    public virtual DbSet<Inputevent> Inputevents { get; set; }

    public virtual DbSet<Labevent> Labevents { get; set; }

    public virtual DbSet<Microbiologyevent> Microbiologyevents { get; set; }

    public virtual DbSet<Omr> Omrs { get; set; }

    public virtual DbSet<Outputevent> Outputevents { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<Poe> Poes { get; set; }

    public virtual DbSet<PoeDetail> PoeDetails { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Procedureevent> Procedureevents { get; set; }

    public virtual DbSet<ProceduresIcd> ProceduresIcds { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Service> Services { get; set; }


    public virtual DbSet<Transfer> Transfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mimic4;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admission>(entity =>
        {
            entity.HasKey(e => e.HadmId).HasName("admissions_pk");

            entity.ToTable("admissions", "mimiciv_hosp");

            entity.HasIndex(e => new { e.Admittime, e.Dischtime, e.Deathtime }, "admissions_idx01");

            entity.Property(e => e.HadmId)
                .ValueGeneratedNever()
                .HasColumnName("hadm_id");
            entity.Property(e => e.AdmissionLocation)
                .HasMaxLength(60)
                .HasColumnName("admission_location");
            entity.Property(e => e.AdmissionType)
                .HasMaxLength(40)
                .HasColumnName("admission_type");
            entity.Property(e => e.AdmitProviderId)
                .HasMaxLength(10)
                .HasColumnName("admit_provider_id");
            entity.Property(e => e.Admittime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("admittime");
            entity.Property(e => e.Deathtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deathtime");
            entity.Property(e => e.DischargeLocation)
                .HasMaxLength(60)
                .HasColumnName("discharge_location");
            entity.Property(e => e.Dischtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dischtime");
            entity.Property(e => e.Edouttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("edouttime");
            entity.Property(e => e.Edregtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("edregtime");
            entity.Property(e => e.HospitalExpireFlag).HasColumnName("hospital_expire_flag");
            entity.Property(e => e.Insurance)
                .HasMaxLength(255)
                .HasColumnName("insurance");
            entity.Property(e => e.Language)
                .HasMaxLength(25)
                .HasColumnName("language");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(30)
                .HasColumnName("marital_status");
            entity.Property(e => e.Race)
                .HasMaxLength(80)
                .HasColumnName("race");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.Admissions)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("admissions_patients_fk");
        });

        modelBuilder.Entity<Caregiver>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("caregiver", "mimiciv_icu");

            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
        });

        modelBuilder.Entity<Chartevent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("chartevents", "mimiciv_icu");

            entity.HasIndex(e => new { e.Charttime, e.Storetime }, "chartevents_idx01");

            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .HasColumnName("value");
            entity.Property(e => e.Valuenum).HasColumnName("valuenum");
            entity.Property(e => e.Valueuom)
                .HasMaxLength(20)
                .HasColumnName("valueuom");
            entity.Property(e => e.Warning).HasColumnName("warning");

            entity.HasOne(d => d.Hadm).WithMany()
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chartevents_admissions_fk");

            entity.HasOne(d => d.Item).WithMany()
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chartevents_d_items_fk");

            entity.HasOne(d => d.Stay).WithMany()
                .HasForeignKey(d => d.StayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chartevents_icustays_fk");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chartevents_patients_fk");
        });

        modelBuilder.Entity<CollectionDisease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("collection_disease_pkey");

            entity.ToTable("collection_disease", "bronze");

            entity.HasIndex(e => e.Charttime, "idx_collection_disease_charttime");

            entity.HasIndex(e => e.HadmId, "idx_collection_disease_hadm_id");

            entity.HasIndex(e => e.Itemid, "idx_collection_disease_itemid");

            entity.HasIndex(e => e.StayId, "idx_collection_disease_stay_id");

            entity.HasIndex(e => e.SubjectId, "idx_collection_disease_subject_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.SourceTable).HasColumnName("source_table");
            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Valuenum).HasColumnName("valuenum");
            entity.Property(e => e.Valueuom).HasColumnName("valueuom");
        });

        modelBuilder.Entity<DHcpc>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("d_hcpcs_pk");

            entity.ToTable("d_hcpcs", "mimiciv_hosp");

            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.LongDescription).HasColumnName("long_description");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(180)
                .HasColumnName("short_description");
        });

        modelBuilder.Entity<DIcdDiagnosis>(entity =>
        {
            entity.HasKey(e => new { e.IcdCode, e.IcdVersion }).HasName("d_icd_diagnoses_pk");

            entity.ToTable("d_icd_diagnoses", "mimiciv_hosp");

            entity.HasIndex(e => e.LongTitle, "d_icd_diag_idx02");

            entity.Property(e => e.IcdCode)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("icd_code");
            entity.Property(e => e.IcdVersion).HasColumnName("icd_version");
            entity.Property(e => e.LongTitle)
                .HasMaxLength(255)
                .HasColumnName("long_title");
        });

        modelBuilder.Entity<DIcdProcedure>(entity =>
        {
            entity.HasKey(e => new { e.IcdCode, e.IcdVersion }).HasName("d_icd_procedures_pk");

            entity.ToTable("d_icd_procedures", "mimiciv_hosp");

            entity.HasIndex(e => e.LongTitle, "d_icd_proc_idx02");

            entity.Property(e => e.IcdCode)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("icd_code");
            entity.Property(e => e.IcdVersion).HasColumnName("icd_version");
            entity.Property(e => e.LongTitle)
                .HasMaxLength(222)
                .HasColumnName("long_title");
        });

        modelBuilder.Entity<DItem>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("d_items_pk");

            entity.ToTable("d_items", "mimiciv_icu");

            entity.HasIndex(e => new { e.Label, e.Abbreviation }, "d_items_idx01");

            entity.HasIndex(e => e.Category, "d_items_idx02");

            entity.Property(e => e.Itemid)
                .ValueGeneratedNever()
                .HasColumnName("itemid");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(50)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Highnormalvalue).HasColumnName("highnormalvalue");
            entity.Property(e => e.Label)
                .HasMaxLength(100)
                .HasColumnName("label");
            entity.Property(e => e.Linksto)
                .HasMaxLength(30)
                .HasColumnName("linksto");
            entity.Property(e => e.Lownormalvalue).HasColumnName("lownormalvalue");
            entity.Property(e => e.ParamType)
                .HasMaxLength(20)
                .HasColumnName("param_type");
            entity.Property(e => e.Unitname)
                .HasMaxLength(50)
                .HasColumnName("unitname");
        });

        modelBuilder.Entity<DLabitem>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("d_labitems_pk");

            entity.ToTable("d_labitems", "mimiciv_hosp");

            entity.HasIndex(e => new { e.Label, e.Fluid, e.Category }, "d_labitems_idx01");

            entity.Property(e => e.Itemid)
                .ValueGeneratedNever()
                .HasColumnName("itemid");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Fluid)
                .HasMaxLength(50)
                .HasColumnName("fluid");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Datetimeevent>(entity =>
        {
            entity.HasKey(e => new { e.StayId, e.Itemid, e.Charttime }).HasName("datetimeevents_pk");

            entity.ToTable("datetimeevents", "mimiciv_icu");

            entity.HasIndex(e => new { e.Charttime, e.Storetime }, "datetimeevents_idx01");

            entity.HasIndex(e => e.Value, "datetimeevents_idx02");

            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Value)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("value");
            entity.Property(e => e.Valueuom)
                .HasMaxLength(20)
                .HasColumnName("valueuom");
            entity.Property(e => e.Warning).HasColumnName("warning");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Datetimeevents)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datetimeevents_admissions_fk");

            entity.HasOne(d => d.Item).WithMany(p => p.Datetimeevents)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datetimeevents_d_items_fk");

            entity.HasOne(d => d.Stay).WithMany(p => p.Datetimeevents)
                .HasForeignKey(d => d.StayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datetimeevents_icustays_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Datetimeevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datetimeevents_patients_fk");
        });

        modelBuilder.Entity<DiagnosesIcd>(entity =>
        {
            entity.HasKey(e => new { e.HadmId, e.SeqNum, e.IcdCode, e.IcdVersion }).HasName("diagnoses_icd_pk");

            entity.ToTable("diagnoses_icd", "mimiciv_hosp");

            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.SeqNum).HasColumnName("seq_num");
            entity.Property(e => e.IcdCode)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("icd_code");
            entity.Property(e => e.IcdVersion).HasColumnName("icd_version");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.DiagnosesIcds)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnoses_icd_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.DiagnosesIcds)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnoses_icd_patients_fk");
        });

        modelBuilder.Entity<Drgcode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("drgcodes", "mimiciv_hosp");

            entity.HasIndex(e => new { e.DrgCode, e.DrgType }, "drgcodes_idx01");

            entity.HasIndex(e => new { e.Description, e.DrgSeverity }, "drgcodes_idx02");

            entity.Property(e => e.Description)
                .HasMaxLength(195)
                .HasColumnName("description");
            entity.Property(e => e.DrgCode)
                .HasMaxLength(10)
                .HasColumnName("drg_code");
            entity.Property(e => e.DrgMortality).HasColumnName("drg_mortality");
            entity.Property(e => e.DrgSeverity).HasColumnName("drg_severity");
            entity.Property(e => e.DrgType)
                .HasMaxLength(4)
                .HasColumnName("drg_type");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany()
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("drgcodes_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("drgcodes_patients_fk");
        });

        modelBuilder.Entity<Emar>(entity =>
        {
            entity.HasKey(e => e.EmarId).HasName("emar_pk");

            entity.ToTable("emar", "mimiciv_hosp");

            entity.HasIndex(e => e.PoeId, "emar_idx01");

            entity.HasIndex(e => e.PharmacyId, "emar_idx02");

            entity.HasIndex(e => new { e.Charttime, e.Scheduletime, e.Storetime }, "emar_idx03");

            entity.HasIndex(e => e.Medication, "emar_idx04");

            entity.Property(e => e.EmarId)
                .HasMaxLength(25)
                .HasColumnName("emar_id");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.EmarSeq).HasColumnName("emar_seq");
            entity.Property(e => e.EnterProviderId)
                .HasMaxLength(10)
                .HasColumnName("enter_provider_id");
            entity.Property(e => e.EventTxt)
                .HasMaxLength(100)
                .HasColumnName("event_txt");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Medication).HasColumnName("medication");
            entity.Property(e => e.PharmacyId).HasColumnName("pharmacy_id");
            entity.Property(e => e.PoeId)
                .HasMaxLength(25)
                .HasColumnName("poe_id");
            entity.Property(e => e.Scheduletime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduletime");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Emars)
                .HasForeignKey(d => d.HadmId)
                .HasConstraintName("emar_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Emars)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emar_patients_fk");
        });

        modelBuilder.Entity<EmarDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("emar_detail", "mimiciv_hosp");

            entity.HasIndex(e => e.ProductDescription, "emar_det_idx04");

            entity.HasIndex(e => e.PharmacyId, "emar_detail_idx01");

            entity.HasIndex(e => e.ProductCode, "emar_detail_idx02");

            entity.HasIndex(e => new { e.Route, e.Site, e.Side }, "emar_detail_idx03");

            entity.Property(e => e.AdministrationType)
                .HasMaxLength(50)
                .HasColumnName("administration_type");
            entity.Property(e => e.BarcodeType)
                .HasMaxLength(4)
                .HasColumnName("barcode_type");
            entity.Property(e => e.CompleteDoseNotGiven)
                .HasMaxLength(5)
                .HasColumnName("complete_dose_not_given");
            entity.Property(e => e.CompletionInterval)
                .HasMaxLength(50)
                .HasColumnName("completion_interval");
            entity.Property(e => e.ContinuedInfusionInOtherLocation)
                .HasMaxLength(1)
                .HasColumnName("continued_infusion_in_other_location");
            entity.Property(e => e.DoseDue)
                .HasMaxLength(100)
                .HasColumnName("dose_due");
            entity.Property(e => e.DoseDueUnit)
                .HasMaxLength(50)
                .HasColumnName("dose_due_unit");
            entity.Property(e => e.DoseGiven)
                .HasMaxLength(255)
                .HasColumnName("dose_given");
            entity.Property(e => e.DoseGivenUnit)
                .HasMaxLength(50)
                .HasColumnName("dose_given_unit");
            entity.Property(e => e.EmarId)
                .HasMaxLength(25)
                .HasColumnName("emar_id");
            entity.Property(e => e.EmarSeq).HasColumnName("emar_seq");
            entity.Property(e => e.InfusionComplete)
                .HasMaxLength(1)
                .HasColumnName("infusion_complete");
            entity.Property(e => e.InfusionRate)
                .HasMaxLength(40)
                .HasColumnName("infusion_rate");
            entity.Property(e => e.InfusionRateAdjustment)
                .HasMaxLength(50)
                .HasColumnName("infusion_rate_adjustment");
            entity.Property(e => e.InfusionRateAdjustmentAmount)
                .HasMaxLength(30)
                .HasColumnName("infusion_rate_adjustment_amount");
            entity.Property(e => e.InfusionRateUnit)
                .HasMaxLength(30)
                .HasColumnName("infusion_rate_unit");
            entity.Property(e => e.NewIvBagHung)
                .HasMaxLength(1)
                .HasColumnName("new_iv_bag_hung");
            entity.Property(e => e.NonFormularyVisualVerification)
                .HasMaxLength(1)
                .HasColumnName("non_formulary_visual_verification");
            entity.Property(e => e.ParentFieldOrdinal)
                .HasMaxLength(10)
                .HasColumnName("parent_field_ordinal");
            entity.Property(e => e.PharmacyId).HasColumnName("pharmacy_id");
            entity.Property(e => e.PriorInfusionRate)
                .HasMaxLength(40)
                .HasColumnName("prior_infusion_rate");
            entity.Property(e => e.ProductAmountGiven)
                .HasMaxLength(30)
                .HasColumnName("product_amount_given");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(255)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductDescriptionOther)
                .HasMaxLength(255)
                .HasColumnName("product_description_other");
            entity.Property(e => e.ProductUnit)
                .HasMaxLength(30)
                .HasColumnName("product_unit");
            entity.Property(e => e.ReasonForNoBarcode).HasColumnName("reason_for_no_barcode");
            entity.Property(e => e.RestartInterval)
                .HasMaxLength(2305)
                .HasColumnName("restart_interval");
            entity.Property(e => e.Route)
                .HasMaxLength(10)
                .HasColumnName("route");
            entity.Property(e => e.Side)
                .HasMaxLength(10)
                .HasColumnName("side");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.WillRemainderOfDoseBeGiven)
                .HasMaxLength(5)
                .HasColumnName("will_remainder_of_dose_be_given");

            entity.HasOne(d => d.Emar).WithMany()
                .HasForeignKey(d => d.EmarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emar_detail_emar_fk");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emar_detail_patients_fk");
        });

        modelBuilder.Entity<Hcpcsevent>(entity =>
        {
            entity.HasKey(e => new { e.HadmId, e.HcpcsCd, e.SeqNum }).HasName("hcpcsevents_pk");

            entity.ToTable("hcpcsevents", "mimiciv_hosp");

            entity.HasIndex(e => e.ShortDescription, "hcpcsevents_idx04");

            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.HcpcsCd)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("hcpcs_cd");
            entity.Property(e => e.SeqNum).HasColumnName("seq_num");
            entity.Property(e => e.Chartdate).HasColumnName("chartdate");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(180)
                .HasColumnName("short_description");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Hcpcsevents)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hcpcsevents_admissions_fk");

            entity.HasOne(d => d.HcpcsCdNavigation).WithMany(p => p.Hcpcsevents)
                .HasForeignKey(d => d.HcpcsCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hcpcsevents_d_hcpcs_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Hcpcsevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hcpcsevents_patients_fk");
        });

        modelBuilder.Entity<Icustay>(entity =>
        {
            entity.HasKey(e => e.StayId).HasName("icustays_pk");

            entity.ToTable("icustays", "mimiciv_icu");

            entity.HasIndex(e => new { e.FirstCareunit, e.LastCareunit }, "icustays_idx01");

            entity.HasIndex(e => new { e.Intime, e.Outtime }, "icustays_idx02");

            entity.Property(e => e.StayId)
                .ValueGeneratedNever()
                .HasColumnName("stay_id");
            entity.Property(e => e.FirstCareunit)
                .HasMaxLength(255)
                .HasColumnName("first_careunit");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Intime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("intime");
            entity.Property(e => e.LastCareunit)
                .HasMaxLength(255)
                .HasColumnName("last_careunit");
            entity.Property(e => e.Los).HasColumnName("los");
            entity.Property(e => e.Outtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("outtime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Icustays)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("icustays_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Icustays)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("icustays_patients_fk");
        });

        modelBuilder.Entity<Ingredientevent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ingredientevents", "mimiciv_icu");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Amountuom)
                .HasMaxLength(20)
                .HasColumnName("amountuom");
            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
            entity.Property(e => e.Endtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endtime");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Linkorderid).HasColumnName("linkorderid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Originalamount).HasColumnName("originalamount");
            entity.Property(e => e.Originalrate).HasColumnName("originalrate");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Rateuom)
                .HasMaxLength(20)
                .HasColumnName("rateuom");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttime");
            entity.Property(e => e.Statusdescription)
                .HasMaxLength(20)
                .HasColumnName("statusdescription");
            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
        });

        modelBuilder.Entity<Inputevent>(entity =>
        {
            entity.HasKey(e => new { e.Orderid, e.Itemid }).HasName("inputevents_pk");

            entity.ToTable("inputevents", "mimiciv_icu");

            entity.HasIndex(e => new { e.Starttime, e.Endtime }, "inputevents_idx01");

            entity.HasIndex(e => e.Ordercategorydescription, "inputevents_idx02");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Amountuom)
                .HasMaxLength(20)
                .HasColumnName("amountuom");
            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
            entity.Property(e => e.Continueinnextdept).HasColumnName("continueinnextdept");
            entity.Property(e => e.Endtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endtime");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Isopenbag).HasColumnName("isopenbag");
            entity.Property(e => e.Linkorderid).HasColumnName("linkorderid");
            entity.Property(e => e.Ordercategorydescription)
                .HasMaxLength(30)
                .HasColumnName("ordercategorydescription");
            entity.Property(e => e.Ordercategoryname)
                .HasMaxLength(50)
                .HasColumnName("ordercategoryname");
            entity.Property(e => e.Ordercomponenttypedescription)
                .HasMaxLength(100)
                .HasColumnName("ordercomponenttypedescription");
            entity.Property(e => e.Originalamount).HasColumnName("originalamount");
            entity.Property(e => e.Originalrate).HasColumnName("originalrate");
            entity.Property(e => e.Patientweight).HasColumnName("patientweight");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Rateuom)
                .HasMaxLength(20)
                .HasColumnName("rateuom");
            entity.Property(e => e.Secondaryordercategoryname)
                .HasMaxLength(50)
                .HasColumnName("secondaryordercategoryname");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttime");
            entity.Property(e => e.Statusdescription)
                .HasMaxLength(20)
                .HasColumnName("statusdescription");
            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Totalamount).HasColumnName("totalamount");
            entity.Property(e => e.Totalamountuom)
                .HasMaxLength(50)
                .HasColumnName("totalamountuom");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Inputevents)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inputevents_admissions_fk");

            entity.HasOne(d => d.Item).WithMany(p => p.Inputevents)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inputevents_d_items_fk");

            entity.HasOne(d => d.Stay).WithMany(p => p.Inputevents)
                .HasForeignKey(d => d.StayId)
                .HasConstraintName("inputevents_icustays_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Inputevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inputevents_patients_fk");
        });

        modelBuilder.Entity<Labevent>(entity =>
        {
            entity.HasKey(e => e.LabeventId).HasName("labevents_pk");

            entity.ToTable("labevents", "mimiciv_hosp");

            entity.HasIndex(e => new { e.Charttime, e.Storetime }, "labevents_idx01");

            entity.HasIndex(e => e.SpecimenId, "labevents_idx02");

            entity.Property(e => e.LabeventId)
                .ValueGeneratedNever()
                .HasColumnName("labevent_id");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Flag)
                .HasMaxLength(10)
                .HasColumnName("flag");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.OrderProviderId)
                .HasMaxLength(10)
                .HasColumnName("order_provider_id");
            entity.Property(e => e.Priority)
                .HasMaxLength(7)
                .HasColumnName("priority");
            entity.Property(e => e.RefRangeLower).HasColumnName("ref_range_lower");
            entity.Property(e => e.RefRangeUpper).HasColumnName("ref_range_upper");
            entity.Property(e => e.SpecimenId).HasColumnName("specimen_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .HasColumnName("value");
            entity.Property(e => e.Valuenum).HasColumnName("valuenum");
            entity.Property(e => e.Valueuom)
                .HasMaxLength(20)
                .HasColumnName("valueuom");

            entity.HasOne(d => d.Item).WithMany(p => p.Labevents)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("labevents_d_labitems_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Labevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("labevents_patients_fk");
        });

        modelBuilder.Entity<Microbiologyevent>(entity =>
        {
            entity.HasKey(e => e.MicroeventId).HasName("microbiologyevents_pk");

            entity.ToTable("microbiologyevents", "mimiciv_hosp");

            entity.HasIndex(e => new { e.Chartdate, e.Charttime, e.Storedate, e.Storetime }, "microbiologyevents_idx01");

            entity.HasIndex(e => new { e.SpecItemid, e.TestItemid, e.OrgItemid, e.AbItemid }, "microbiologyevents_idx02");

            entity.HasIndex(e => e.MicroSpecimenId, "microbiologyevents_idx03");

            entity.Property(e => e.MicroeventId)
                .ValueGeneratedNever()
                .HasColumnName("microevent_id");
            entity.Property(e => e.AbItemid).HasColumnName("ab_itemid");
            entity.Property(e => e.AbName)
                .HasMaxLength(30)
                .HasColumnName("ab_name");
            entity.Property(e => e.Chartdate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("chartdate");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.DilutionComparison)
                .HasMaxLength(20)
                .HasColumnName("dilution_comparison");
            entity.Property(e => e.DilutionText)
                .HasMaxLength(10)
                .HasColumnName("dilution_text");
            entity.Property(e => e.DilutionValue).HasColumnName("dilution_value");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Interpretation)
                .HasMaxLength(5)
                .HasColumnName("interpretation");
            entity.Property(e => e.IsolateNum).HasColumnName("isolate_num");
            entity.Property(e => e.MicroSpecimenId).HasColumnName("micro_specimen_id");
            entity.Property(e => e.OrderProviderId)
                .HasMaxLength(10)
                .HasColumnName("order_provider_id");
            entity.Property(e => e.OrgItemid).HasColumnName("org_itemid");
            entity.Property(e => e.OrgName)
                .HasMaxLength(100)
                .HasColumnName("org_name");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .HasColumnName("quantity");
            entity.Property(e => e.SpecItemid).HasColumnName("spec_itemid");
            entity.Property(e => e.SpecTypeDesc)
                .HasMaxLength(100)
                .HasColumnName("spec_type_desc");
            entity.Property(e => e.Storedate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("storedate");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TestItemid).HasColumnName("test_itemid");
            entity.Property(e => e.TestName)
                .HasMaxLength(100)
                .HasColumnName("test_name");
            entity.Property(e => e.TestSeq).HasColumnName("test_seq");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Microbiologyevents)
                .HasForeignKey(d => d.HadmId)
                .HasConstraintName("microbiologyevents_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Microbiologyevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("microbiologyevents_patients_fk");
        });

        modelBuilder.Entity<Omr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("omr", "mimiciv_hosp");

            entity.Property(e => e.Chartdate).HasColumnName("chartdate");
            entity.Property(e => e.ResultName)
                .HasMaxLength(100)
                .HasColumnName("result_name");
            entity.Property(e => e.ResultValue).HasColumnName("result_value");
            entity.Property(e => e.SeqNum).HasColumnName("seq_num");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
        });

        modelBuilder.Entity<Outputevent>(entity =>
        {
            entity.HasKey(e => new { e.StayId, e.Charttime, e.Itemid }).HasName("outputevents_pk");

            entity.ToTable("outputevents", "mimiciv_icu");

            entity.HasIndex(e => new { e.Charttime, e.Storetime }, "outputevents_idx01");

            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Charttime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("charttime");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Valueuom)
                .HasMaxLength(20)
                .HasColumnName("valueuom");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Outputevents)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("outputevents_admissions_fk");

            entity.HasOne(d => d.Item).WithMany(p => p.Outputevents)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("outputevents_d_items_fk");

            entity.HasOne(d => d.Stay).WithMany(p => p.Outputevents)
                .HasForeignKey(d => d.StayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("outputevents_icustays_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Outputevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("outputevents_patients_fk");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("patients_pk");

            entity.ToTable("patients", "mimiciv_hosp");

            entity.HasIndex(e => e.AnchorAge, "patients_idx01");

            entity.HasIndex(e => e.AnchorYear, "patients_idx02");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subject_id");
            entity.Property(e => e.AnchorAge).HasColumnName("anchor_age");
            entity.Property(e => e.AnchorYear).HasColumnName("anchor_year");
            entity.Property(e => e.AnchorYearGroup)
                .HasMaxLength(20)
                .HasColumnName("anchor_year_group");
            entity.Property(e => e.Dod).HasColumnName("dod");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.PharmacyId).HasName("pharmacy_pk");

            entity.ToTable("pharmacy", "mimiciv_hosp");

            entity.HasIndex(e => e.PoeId, "pharmacy_idx01");

            entity.HasIndex(e => new { e.Starttime, e.Stoptime }, "pharmacy_idx02");

            entity.HasIndex(e => e.Medication, "pharmacy_idx03");

            entity.HasIndex(e => e.Route, "pharmacy_idx04");

            entity.Property(e => e.PharmacyId)
                .ValueGeneratedNever()
                .HasColumnName("pharmacy_id");
            entity.Property(e => e.BasalRate).HasColumnName("basal_rate");
            entity.Property(e => e.DispSched)
                .HasMaxLength(255)
                .HasColumnName("disp_sched");
            entity.Property(e => e.Dispensation)
                .HasMaxLength(50)
                .HasColumnName("dispensation");
            entity.Property(e => e.DosesPer24Hrs).HasColumnName("doses_per_24_hrs");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.DurationInterval)
                .HasMaxLength(50)
                .HasColumnName("duration_interval");
            entity.Property(e => e.Entertime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("entertime");
            entity.Property(e => e.ExpirationUnit)
                .HasMaxLength(50)
                .HasColumnName("expiration_unit");
            entity.Property(e => e.ExpirationValue).HasColumnName("expiration_value");
            entity.Property(e => e.Expirationdate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("expirationdate");
            entity.Property(e => e.FillQuantity)
                .HasMaxLength(50)
                .HasColumnName("fill_quantity");
            entity.Property(e => e.Frequency)
                .HasMaxLength(50)
                .HasColumnName("frequency");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.InfusionType)
                .HasMaxLength(15)
                .HasColumnName("infusion_type");
            entity.Property(e => e.LockoutInterval)
                .HasMaxLength(50)
                .HasColumnName("lockout_interval");
            entity.Property(e => e.Medication).HasColumnName("medication");
            entity.Property(e => e.OneHrMax)
                .HasMaxLength(10)
                .HasColumnName("one_hr_max");
            entity.Property(e => e.PoeId)
                .HasMaxLength(25)
                .HasColumnName("poe_id");
            entity.Property(e => e.ProcType)
                .HasMaxLength(50)
                .HasColumnName("proc_type");
            entity.Property(e => e.Route)
                .HasMaxLength(50)
                .HasColumnName("route");
            entity.Property(e => e.SlidingScale)
                .HasMaxLength(1)
                .HasColumnName("sliding_scale");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("starttime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Stoptime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("stoptime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Verifiedtime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("verifiedtime");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Pharmacies)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pharmacy_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Pharmacies)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pharmacy_patients_fk");
        });

        modelBuilder.Entity<Poe>(entity =>
        {
            entity.HasKey(e => e.PoeId).HasName("poe_pk");

            entity.ToTable("poe", "mimiciv_hosp");

            entity.HasIndex(e => e.OrderType, "poe_idx01");

            entity.Property(e => e.PoeId)
                .HasMaxLength(25)
                .HasColumnName("poe_id");
            entity.Property(e => e.DiscontinueOfPoeId)
                .HasMaxLength(25)
                .HasColumnName("discontinue_of_poe_id");
            entity.Property(e => e.DiscontinuedByPoeId)
                .HasMaxLength(25)
                .HasColumnName("discontinued_by_poe_id");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.OrderProviderId)
                .HasMaxLength(10)
                .HasColumnName("order_provider_id");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(15)
                .HasColumnName("order_status");
            entity.Property(e => e.OrderSubtype)
                .HasMaxLength(50)
                .HasColumnName("order_subtype");
            entity.Property(e => e.OrderType)
                .HasMaxLength(25)
                .HasColumnName("order_type");
            entity.Property(e => e.Ordertime)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("ordertime");
            entity.Property(e => e.PoeSeq).HasColumnName("poe_seq");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(15)
                .HasColumnName("transaction_type");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Poes)
                .HasForeignKey(d => d.HadmId)
                .HasConstraintName("poe_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Poes)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("poe_patients_fk");
        });

        modelBuilder.Entity<PoeDetail>(entity =>
        {
            entity.HasKey(e => new { e.PoeId, e.FieldName }).HasName("poe_detail_pk");

            entity.ToTable("poe_detail", "mimiciv_hosp");

            entity.Property(e => e.PoeId)
                .HasMaxLength(25)
                .HasColumnName("poe_id");
            entity.Property(e => e.FieldName)
                .HasMaxLength(255)
                .HasColumnName("field_name");
            entity.Property(e => e.FieldValue).HasColumnName("field_value");
            entity.Property(e => e.PoeSeq).HasColumnName("poe_seq");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Poe).WithMany(p => p.PoeDetails)
                .HasForeignKey(d => d.PoeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("poe_detail_poe_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.PoeDetails)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("poe_detail_patients_fk");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => new { e.PharmacyId, e.DrugType, e.Drug }).HasName("prescriptions_pk");

            entity.ToTable("prescriptions", "mimiciv_hosp");

            entity.HasIndex(e => new { e.Starttime, e.Stoptime }, "prescriptions_idx01");

            entity.Property(e => e.PharmacyId).HasColumnName("pharmacy_id");
            entity.Property(e => e.DrugType)
                .HasMaxLength(20)
                .HasColumnName("drug_type");
            entity.Property(e => e.Drug)
                .HasMaxLength(255)
                .HasColumnName("drug");
            entity.Property(e => e.DoseUnitRx)
                .HasMaxLength(50)
                .HasColumnName("dose_unit_rx");
            entity.Property(e => e.DoseValRx)
                .HasMaxLength(100)
                .HasColumnName("dose_val_rx");
            entity.Property(e => e.DosesPer24Hrs).HasColumnName("doses_per_24_hrs");
            entity.Property(e => e.FormRx)
                .HasMaxLength(25)
                .HasColumnName("form_rx");
            entity.Property(e => e.FormUnitDisp)
                .HasMaxLength(50)
                .HasColumnName("form_unit_disp");
            entity.Property(e => e.FormValDisp)
                .HasMaxLength(50)
                .HasColumnName("form_val_disp");
            entity.Property(e => e.FormularyDrugCd)
                .HasMaxLength(50)
                .HasColumnName("formulary_drug_cd");
            entity.Property(e => e.Gsn)
                .HasMaxLength(255)
                .HasColumnName("gsn");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Ndc)
                .HasMaxLength(25)
                .HasColumnName("ndc");
            entity.Property(e => e.OrderProviderId)
                .HasMaxLength(10)
                .HasColumnName("order_provider_id");
            entity.Property(e => e.PoeId)
                .HasMaxLength(25)
                .HasColumnName("poe_id");
            entity.Property(e => e.PoeSeq).HasColumnName("poe_seq");
            entity.Property(e => e.ProdStrength)
                .HasMaxLength(255)
                .HasColumnName("prod_strength");
            entity.Property(e => e.Route)
                .HasMaxLength(50)
                .HasColumnName("route");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("starttime");
            entity.Property(e => e.Stoptime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("stoptime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescriptions_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prescriptions_patients_fk");
        });

        modelBuilder.Entity<Procedureevent>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("procedureevents_pk");

            entity.ToTable("procedureevents", "mimiciv_icu");

            entity.HasIndex(e => new { e.Starttime, e.Endtime }, "procedureevents_idx01");

            entity.HasIndex(e => e.Ordercategoryname, "procedureevents_idx02");

            entity.Property(e => e.Orderid)
                .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.CaregiverId).HasColumnName("caregiver_id");
            entity.Property(e => e.Continueinnextdept).HasColumnName("continueinnextdept");
            entity.Property(e => e.Endtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endtime");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Isopenbag).HasColumnName("isopenbag");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Linkorderid).HasColumnName("linkorderid");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Locationcategory)
                .HasMaxLength(50)
                .HasColumnName("locationcategory");
            entity.Property(e => e.Ordercategorydescription)
                .HasMaxLength(30)
                .HasColumnName("ordercategorydescription");
            entity.Property(e => e.Ordercategoryname)
                .HasMaxLength(50)
                .HasColumnName("ordercategoryname");
            entity.Property(e => e.Originalamount).HasColumnName("originalamount");
            entity.Property(e => e.Originalrate).HasColumnName("originalrate");
            entity.Property(e => e.Patientweight).HasColumnName("patientweight");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttime");
            entity.Property(e => e.Statusdescription)
                .HasMaxLength(20)
                .HasColumnName("statusdescription");
            entity.Property(e => e.StayId).HasColumnName("stay_id");
            entity.Property(e => e.Storetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("storetime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Valueuom)
                .HasMaxLength(20)
                .HasColumnName("valueuom");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Procedureevents)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procedureevents_admissions_fk");

            entity.HasOne(d => d.Item).WithMany(p => p.Procedureevents)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procedureevents_d_items_fk");

            entity.HasOne(d => d.Stay).WithMany(p => p.Procedureevents)
                .HasForeignKey(d => d.StayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procedureevents_icustays_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Procedureevents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procedureevents_patients_fk");
        });

        modelBuilder.Entity<ProceduresIcd>(entity =>
        {
            entity.HasKey(e => new { e.HadmId, e.SeqNum, e.IcdCode, e.IcdVersion }).HasName("procedures_icd_pk");

            entity.ToTable("procedures_icd", "mimiciv_hosp");

            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.SeqNum).HasColumnName("seq_num");
            entity.Property(e => e.IcdCode)
                .HasMaxLength(7)
                .HasColumnName("icd_code");
            entity.Property(e => e.IcdVersion).HasColumnName("icd_version");
            entity.Property(e => e.Chartdate).HasColumnName("chartdate");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.ProceduresIcds)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procedures_icd_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.ProceduresIcds)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("procedures_icd_patients_fk");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("provider", "mimiciv_hosp");

            entity.Property(e => e.ProviderId)
                .HasMaxLength(10)
                .HasColumnName("provider_id");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => new { e.HadmId, e.Transfertime, e.CurrService }).HasName("services_pk");

            entity.ToTable("services", "mimiciv_hosp");

            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Transfertime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transfertime");
            entity.Property(e => e.CurrService)
                .HasMaxLength(10)
                .HasColumnName("curr_service");
            entity.Property(e => e.PrevService)
                .HasMaxLength(10)
                .HasColumnName("prev_service");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Hadm).WithMany(p => p.Services)
                .HasForeignKey(d => d.HadmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("services_admissions_fk");

            entity.HasOne(d => d.Subject).WithMany(p => p.Services)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("services_patients_fk");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("transfers_pk");

            entity.ToTable("transfers", "mimiciv_hosp");

            entity.HasIndex(e => e.HadmId, "transfers_idx01");

            entity.HasIndex(e => e.Intime, "transfers_idx02");

            entity.HasIndex(e => e.Careunit, "transfers_idx03");

            entity.Property(e => e.TransferId)
                .ValueGeneratedNever()
                .HasColumnName("transfer_id");
            entity.Property(e => e.Careunit)
                .HasMaxLength(255)
                .HasColumnName("careunit");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(10)
                .HasColumnName("eventtype");
            entity.Property(e => e.HadmId).HasColumnName("hadm_id");
            entity.Property(e => e.Intime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("intime");
            entity.Property(e => e.Outtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("outtime");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transfers_patients_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
