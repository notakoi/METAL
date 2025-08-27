using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class ProceduresIcd
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int SeqNum { get; set; }

    public DateOnly Chartdate { get; set; }

    public string IcdCode { get; set; } = null!;

    public short IcdVersion { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
