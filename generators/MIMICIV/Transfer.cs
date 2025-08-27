using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Transfer
{
    public int SubjectId { get; set; }

    public int? HadmId { get; set; }

    public int TransferId { get; set; }

    public string? Eventtype { get; set; }

    public string? Careunit { get; set; }

    public DateTime? Intime { get; set; }

    public DateTime? Outtime { get; set; }

    public virtual Patient Subject { get; set; } = null!;
}
