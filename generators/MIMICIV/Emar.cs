using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Emar
{
    public int SubjectId { get; set; }

    public int? HadmId { get; set; }

    public string EmarId { get; set; } = null!;

    public int EmarSeq { get; set; }

    public string PoeId { get; set; } = null!;

    public int? PharmacyId { get; set; }

    public string? EnterProviderId { get; set; }

    public DateTime Charttime { get; set; }

    public string? Medication { get; set; }

    public string? EventTxt { get; set; }

    public DateTime? Scheduletime { get; set; }

    public DateTime Storetime { get; set; }

    public virtual Admission? Hadm { get; set; }

    public virtual Patient Subject { get; set; } = null!;
}
