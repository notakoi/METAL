using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class DItem
{
    public int Itemid { get; set; }

    public string Label { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string Linksto { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? Unitname { get; set; }

    public string ParamType { get; set; } = null!;

    public double? Lownormalvalue { get; set; }

    public double? Highnormalvalue { get; set; }

    public virtual ICollection<Datetimeevent> Datetimeevents { get; set; } = new List<Datetimeevent>();

    public virtual ICollection<Inputevent> Inputevents { get; set; } = new List<Inputevent>();

    public virtual ICollection<Outputevent> Outputevents { get; set; } = new List<Outputevent>();

    public virtual ICollection<Procedureevent> Procedureevents { get; set; } = new List<Procedureevent>();
}
