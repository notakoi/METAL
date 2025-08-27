using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class CollectionDisease
{
    public int Id { get; set; }

    public int SubjectId { get; set; }

    public int? HadmId { get; set; }

    public int? StayId { get; set; }

    public DateTime? Charttime { get; set; }

    public DateTime? Storetime { get; set; }

    public int Itemid { get; set; }

    public string? Value { get; set; }

    public decimal? Valuenum { get; set; }

    public string? Valueuom { get; set; }

    public string? SourceTable { get; set; }
}
