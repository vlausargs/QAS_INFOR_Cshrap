//PROJECT NAME: Finance
//CLASS NAME: ICLM_FixedAssetDetailTranCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface ICLM_FixedAssetDetailTranCRUD
    {
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_FixedAssetDetailTranSp(string AltExtGenSp, string Ref = null);
        ICollectionLoadResponse FamasterSelect(string FaNum);
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        ICollectionLoadResponse Optional_Module1Select();
        bool Optional_ModuleForExists();
        (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        bool Tv_ALTGENForExists();
    }
}