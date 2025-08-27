using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Patient
{
    public int SubjectId { get; set; }

    public char Gender { get; set; }

    public short? AnchorAge { get; set; }

    public short AnchorYear { get; set; }

    public string AnchorYearGroup { get; set; } = null!;

    public DateOnly? Dod { get; set; }

    public virtual ICollection<Admission> Admissions { get; set; } = new List<Admission>();

    public virtual ICollection<Datetimeevent> Datetimeevents { get; set; } = new List<Datetimeevent>();

    public virtual ICollection<DiagnosesIcd> DiagnosesIcds { get; set; } = new List<DiagnosesIcd>();

    public virtual ICollection<Emar> Emars { get; set; } = new List<Emar>();

    public virtual ICollection<Hcpcsevent> Hcpcsevents { get; set; } = new List<Hcpcsevent>();

    public virtual ICollection<Icustay> Icustays { get; set; } = new List<Icustay>();

    public virtual ICollection<Inputevent> Inputevents { get; set; } = new List<Inputevent>();

    public virtual ICollection<Labevent> Labevents { get; set; } = new List<Labevent>();

    public virtual ICollection<Microbiologyevent> Microbiologyevents { get; set; } = new List<Microbiologyevent>();

    public virtual ICollection<Outputevent> Outputevents { get; set; } = new List<Outputevent>();

    public virtual ICollection<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>();

    public virtual ICollection<PoeDetail> PoeDetails { get; set; } = new List<PoeDetail>();

    public virtual ICollection<Poe> Poes { get; set; } = new List<Poe>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Procedureevent> Procedureevents { get; set; } = new List<Procedureevent>();

    public virtual ICollection<ProceduresIcd> ProceduresIcds { get; set; } = new List<ProceduresIcd>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
