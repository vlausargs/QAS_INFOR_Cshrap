//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SlsmanReportsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_SlsmanReportsCRUD
    {
        bool CheckOptional_ModuleForExists();
        ICollectionLoadResponse SelectOptional_Module();
        void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
        bool CheckTv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
        ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName);
        void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse SelectSlsman(string UserName);
        void InsertSlsman(ICollectionLoadResponse slsmanLoadResponse);
        ICollectionLoadResponse SelectSlsman(int? Level);
        ICollectionLoadResponse SelectTv_Directreports(int? DisplayLevel);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_SlsmanReportsSp(string AltExtGenSp, string UserName, int? DisplayLevel);
    }
}

