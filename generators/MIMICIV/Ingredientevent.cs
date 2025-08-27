using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Ingredientevent
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int? StayId { get; set; }

    public int? CaregiverId { get; set; }

    public DateTime Starttime { get; set; }

    public DateTime Endtime { get; set; }

    public DateTime? Storetime { get; set; }

    public int Itemid { get; set; }

    public double? Amount { get; set; }

    public string? Amountuom { get; set; }

    public double? Rate { get; set; }

    public string? Rateuom { get; set; }

    public int Orderid { get; set; }

    public int? Linkorderid { get; set; }

    public string? Statusdescription { get; set; }

    public double? Originalamount { get; set; }

    public double? Originalrate { get; set; }
}
