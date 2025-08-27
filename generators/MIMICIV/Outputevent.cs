using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Outputevent
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int StayId { get; set; }

    public int? CaregiverId { get; set; }

    public DateTime Charttime { get; set; }

    public DateTime Storetime { get; set; }

    public int Itemid { get; set; }

    public double Value { get; set; }

    public string? Valueuom { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual DItem Item { get; set; } = null!;

    public virtual Icustay Stay { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
