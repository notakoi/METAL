using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class DIcdProcedure
{
    public string IcdCode { get; set; } = null!;

    public short IcdVersion { get; set; }

    public string? LongTitle { get; set; }
}
