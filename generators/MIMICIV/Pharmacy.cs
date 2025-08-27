using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Pharmacy
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int PharmacyId { get; set; }

    public string? PoeId { get; set; }

    public DateTime? Starttime { get; set; }

    public DateTime? Stoptime { get; set; }

    public string? Medication { get; set; }

    public string ProcType { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime Entertime { get; set; }

    public DateTime? Verifiedtime { get; set; }

    public string? Route { get; set; }

    public string? Frequency { get; set; }

    public string? DispSched { get; set; }

    public string? InfusionType { get; set; }

    public string? SlidingScale { get; set; }

    public string? LockoutInterval { get; set; }

    public float? BasalRate { get; set; }

    public string? OneHrMax { get; set; }

    public float? DosesPer24Hrs { get; set; }

    public float? Duration { get; set; }

    public string? DurationInterval { get; set; }

    public int? ExpirationValue { get; set; }

    public string? ExpirationUnit { get; set; }

    public DateTime? Expirationdate { get; set; }

    public string? Dispensation { get; set; }

    public string? FillQuantity { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
