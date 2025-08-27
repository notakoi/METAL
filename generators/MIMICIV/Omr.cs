using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Omr
{
    public int SubjectId { get; set; }

    public DateOnly Chartdate { get; set; }

    public int SeqNum { get; set; }

    public string ResultName { get; set; } = null!;

    public string ResultValue { get; set; } = null!;
}
