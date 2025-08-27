using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Admission
{
    public int SubjectId { get; set; }

    public int HadmId { get; set; }

    public DateTime Admittime { get; set; }

    public DateTime? Dischtime { get; set; }

    public DateTime? Deathtime { get; set; }

    public string AdmissionType { get; set; } = null!;

    public string? AdmitProviderId { get; set; }

    public string? AdmissionLocation { get; set; }

    public string? DischargeLocation { get; set; }

    public string? Insurance { get; set; }

    public string? Language { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Race { get; set; }

    public DateTime? Edregtime { get; set; }

    public DateTime? Edouttime { get; set; }

    public short? HospitalExpireFlag { get; set; }

    public virtual ICollection<Datetimeevent> Datetimeevents { get; set; } = new List<Datetimeevent>();

    public virtual ICollection<DiagnosesIcd> DiagnosesIcds { get; set; } = new List<DiagnosesIcd>();

    public virtual ICollection<Emar> Emars { get; set; } = new List<Emar>();

    public virtual ICollection<Hcpcsevent> Hcpcsevents { get; set; } = new List<Hcpcsevent>();

    public virtual ICollection<Icustay> Icustays { get; set; } = new List<Icustay>();

    public virtual ICollection<Inputevent> Inputevents { get; set; } = new List<Inputevent>();

    public virtual ICollection<Microbiologyevent> Microbiologyevents { get; set; } = new List<Microbiologyevent>();

    public virtual ICollection<Outputevent> Outputevents { get; set; } = new List<Outputevent>();

    public virtual ICollection<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>();

    public virtual ICollection<Poe> Poes { get; set; } = new List<Poe>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Procedureevent> Procedureevents { get; set; } = new List<Procedureevent>();

    public virtual ICollection<ProceduresIcd> ProceduresIcds { get; set; } = new List<ProceduresIcd>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual Patient Subject { get; set; } = null!;
}
