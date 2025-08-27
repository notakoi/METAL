using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Labevent
{
    public int LabeventId { get; set; }

    public int SubjectId { get; set; }

    public int? HadmId { get; set; }

    public int SpecimenId { get; set; }

    public int Itemid { get; set; }

    public string? OrderProviderId { get; set; }

    public DateTime? Charttime { get; set; }

    public DateTime? Storetime { get; set; }

    public string? Value { get; set; }

    public double? Valuenum { get; set; }

    public string? Valueuom { get; set; }

    public double? RefRangeLower { get; set; }

    public double? RefRangeUpper { get; set; }

    public string? Flag { get; set; }

    public string? Priority { get; set; }

    public string? Comments { get; set; }

    public virtual DLabitem Item { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
