//PROJECT NAME: Production
//CLASS NAME: IPmfRptSelectSessPnsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
    public interface IPmfRptSelectSessPnsCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Vpmfrptpn1Select(Guid? SessionId, int? Seq);
        ICollectionLoadResponse Pmf_Tmp_Rpt_PnSelect(Guid? SessionId, int? Seq);
        void Pmf_Tmp_Rpt_PnDelete(ICollectionLoadResponse pmf_tmp_rpt_pnLoadResponse);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_PmfRptSelectSessPnsSp(string AltExtGenSp, Guid? SessionId, int? Seq, int? ClearSess);
    }
}

