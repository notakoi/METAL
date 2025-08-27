using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class PoeDetail
{
    public string PoeId { get; set; } = null!;

    public int PoeSeq { get; set; }

    public int SubjectId { get; set; }

    public string FieldName { get; set; } = null!;

    public string? FieldValue { get; set; }

    public virtual Poe Poe { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
