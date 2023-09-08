//PROJECT NAME: Material
//CLASS NAME: ICLM_ItemComplianceAssignment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface ICLM_ItemComplianceAssignment
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ItemComplianceAssignmentSp(
            int? ProcessAll = 0,
            string ComplianceProgramId = null,
            string Mode = "N",
            DateTime? EffectDate = null);
    }
}

