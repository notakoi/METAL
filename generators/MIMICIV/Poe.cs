using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class Poe
{
    public string PoeId { get; set; } = null!;

    public int PoeSeq { get; set; }

    public int SubjectId { get; set; }

    public int? HadmId { get; set; }

    public DateTime Ordertime { get; set; }

    public string OrderType { get; set; } = null!;

    public string? OrderSubtype { get; set; }

    public string? TransactionType { get; set; }

    public string? DiscontinueOfPoeId { get; set; }

    public string? DiscontinuedByPoeId { get; set; }

    public string? OrderProviderId { get; set; }

    public string? OrderStatus { get; set; }

    public virtual Admission? Hadm { get; set; }

    public virtual ICollection<PoeDetail> PoeDetails { get; set; } = new List<PoeDetail>();

    public virtual Patient Subject { get; set; } = null!;
}
