using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Service
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public DateTime Transfertime { get; set; }

    public string? PrevService { get; set; }

    public string CurrService { get; set; } = null!;

    public virtual Admission Hadm { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
