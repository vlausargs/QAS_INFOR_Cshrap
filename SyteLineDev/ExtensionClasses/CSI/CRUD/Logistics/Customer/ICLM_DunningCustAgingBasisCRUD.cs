//PROJECT NAME: Logistics
//CLASS NAME: ICLM_DunningCustAgingBasisCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_DunningCustAgingBasisCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse _1Select(string CustNum, string SiteRef);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_DunningCustAgingBasisSp(string AltExtGenSp, string CustNum, string SiteRef);
    }
}

