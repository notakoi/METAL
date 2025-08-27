using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class DHcpc
{
    public string Code { get; set; } = null!;

    public short? Category { get; set; }

    public string? LongDescription { get; set; }

    public string? ShortDescription { get; set; }

    public virtual ICollection<Hcpcsevent> Hcpcsevents { get; set; } = new List<Hcpcsevent>();
}
