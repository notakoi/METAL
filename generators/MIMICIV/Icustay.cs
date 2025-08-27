using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Icustay
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public int StayId { get; set; }

    public string? FirstCareunit { get; set; }

    public string? LastCareunit { get; set; }

    public DateTime? Intime { get; set; }

    public DateTime? Outtime { get; set; }

    public double? Los { get; set; }

    public virtual ICollection<Datetimeevent> Datetimeevents { get; set; } = new List<Datetimeevent>();

    public virtual Admission Hadm { get; set; } = null!;

    public virtual ICollection<Inputevent> Inputevents { get; set; } = new List<Inputevent>();

    public virtual ICollection<Outputevent> Outputevents { get; set; } = new List<Outputevent>();

    public virtual ICollection<Procedureevent> Procedureevents { get; set; } = new List<Procedureevent>();

    public virtual Patient Subject { get; set; } = null!;
}
