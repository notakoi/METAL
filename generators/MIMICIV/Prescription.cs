using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Prescription
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int PharmacyId { get; set; }

    public string? PoeId { get; set; }

    public int? PoeSeq { get; set; }

    public string? OrderProviderId { get; set; }

    public DateTime? Starttime { get; set; }

    public DateTime? Stoptime { get; set; }

    public string DrugType { get; set; } = null!;

    public string Drug { get; set; } = null!;

    public string? FormularyDrugCd { get; set; }

    public string? Gsn { get; set; }

    public string? Ndc { get; set; }

    public string? ProdStrength { get; set; }

    public string? FormRx { get; set; }

    public string? DoseValRx { get; set; }

    public string? DoseUnitRx { get; set; }

    public string? FormValDisp { get; set; }

    public string? FormUnitDisp { get; set; }

    public float? DosesPer24Hrs { get; set; }

    public string? Route { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
