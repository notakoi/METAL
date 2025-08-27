using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Hcpcsevent
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public DateOnly? Chartdate { get; set; }

    public string HcpcsCd { get; set; } = null!;

    public int SeqNum { get; set; }

    public string? ShortDescription { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual DHcpc HcpcsCdNavigation { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
