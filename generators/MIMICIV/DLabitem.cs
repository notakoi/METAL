using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class DLabitem
{
    public int Itemid { get; set; }

    public string? Label { get; set; }

    public string? Fluid { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<Labevent> Labevents { get; set; } = new List<Labevent>();
}
