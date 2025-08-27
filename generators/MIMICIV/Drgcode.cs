using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Drgcode
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public string? DrgType { get; set; }

    public string DrgCode { get; set; } = null!;

    public string? Description { get; set; }

    public short? DrgSeverity { get; set; }

    public short? DrgMortality { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
