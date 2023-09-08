//PROJECT NAME: Material
//CLASS NAME: ICLM_ItemComplianceAssignmentCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface ICLM_ItemComplianceAssignmentCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Tempitemcompliance1Select(int? Severity, int? ProcessAll, string ComplianceProgramId, string Mode, string Infobar, DateTime? EffectDate);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ItemComplianceAssignmentSp(string AltExtGenSp, int? ProcessAll, string ComplianceProgramId, string Mode, DateTime? EffectDate);
    }
}

