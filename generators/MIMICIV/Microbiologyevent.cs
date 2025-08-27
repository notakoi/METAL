using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Microbiologyevent
{
    public int MicroeventId { get; set; }

    public int SubjectId { get; set; }

    public int? HadmId { get; set; }

    public int MicroSpecimenId { get; set; }

    public string? OrderProviderId { get; set; }

    public DateTime Chartdate { get; set; }

    public DateTime? Charttime { get; set; }

    public int SpecItemid { get; set; }

    public string SpecTypeDesc { get; set; } = null!;

    public int TestSeq { get; set; }

    public DateTime? Storedate { get; set; }

    public DateTime? Storetime { get; set; }

    public int? TestItemid { get; set; }

    public string? TestName { get; set; }

    public int? OrgItemid { get; set; }

    public string? OrgName { get; set; }

    public short? IsolateNum { get; set; }

    public string? Quantity { get; set; }

    public int? AbItemid { get; set; }

    public string? AbName { get; set; }

    public string? DilutionText { get; set; }

    public string? DilutionComparison { get; set; }

    public double? DilutionValue { get; set; }

    public string? Interpretation { get; set; }

    public string? Comments { get; set; }

    public virtual Admission? Hadm { get; set; }

    public virtual Patient Subject { get; set; } = null!;
}
