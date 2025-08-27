using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Procedureevent
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int StayId { get; set; }

    public int? CaregiverId { get; set; }

    public DateTime Starttime { get; set; }

    public DateTime Endtime { get; set; }

    public DateTime Storetime { get; set; }

    public int Itemid { get; set; }

    public double? Value { get; set; }

    public string? Valueuom { get; set; }

    public string? Location { get; set; }

    public string? Locationcategory { get; set; }

    public int Orderid { get; set; }

    public int? Linkorderid { get; set; }

    public string? Ordercategoryname { get; set; }

    public string? Ordercategorydescription { get; set; }

    public double? Patientweight { get; set; }

    public short? Isopenbag { get; set; }

    public short? Continueinnextdept { get; set; }

    public string? Statusdescription { get; set; }

    public double? Originalamount { get; set; }

    public double? Originalrate { get; set; }

    public virtual Admission Hadm { get; set; } = null!;

    public virtual DItem Item { get; set; } = null!;

    public virtual Icustay Stay { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
