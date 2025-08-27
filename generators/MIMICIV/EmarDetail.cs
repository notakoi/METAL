using System;
using System.Collections.Generic;

namespace generators.MIMICIV;

public partial class EmarDetail
{
    public int SubjectId { get; set; }

    public string EmarId { get; set; } = null!;

    public int EmarSeq { get; set; }

    public string? ParentFieldOrdinal { get; set; }

    public string? AdministrationType { get; set; }

    public int? PharmacyId { get; set; }

    public string? BarcodeType { get; set; }

    public string? ReasonForNoBarcode { get; set; }

    public string? CompleteDoseNotGiven { get; set; }

    public string? DoseDue { get; set; }

    public string? DoseDueUnit { get; set; }

    public string? DoseGiven { get; set; }

    public string? DoseGivenUnit { get; set; }

    public string? WillRemainderOfDoseBeGiven { get; set; }

    public string? ProductAmountGiven { get; set; }

    public string? ProductUnit { get; set; }

    public string? ProductCode { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductDescriptionOther { get; set; }

    public string? PriorInfusionRate { get; set; }

    public string? InfusionRate { get; set; }

    public string? InfusionRateAdjustment { get; set; }

    public string? InfusionRateAdjustmentAmount { get; set; }

    public string? InfusionRateUnit { get; set; }

    public string? Route { get; set; }

    public string? InfusionComplete { get; set; }

    public string? CompletionInterval { get; set; }

    public string? NewIvBagHung { get; set; }

    public string? ContinuedInfusionInOtherLocation { get; set; }

    public string? RestartInterval { get; set; }

    public string? Side { get; set; }

    public string? Site { get; set; }

    public string? NonFormularyVisualVerification { get; set; }

    public virtual Emar Emar { get; set; } = null!;

    public virtual Patient Subject { get; set; } = null!;
}
