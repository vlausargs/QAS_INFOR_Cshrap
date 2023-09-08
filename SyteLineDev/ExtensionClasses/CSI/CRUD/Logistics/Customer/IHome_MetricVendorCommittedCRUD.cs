//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricVendorCommittedCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricVendorCommittedCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse Poitem1Select(int? Count);
        ICollectionLoadResponse Poitem3Select();
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricVendorCommittedSp(string AltExtGenSp, int? Count);
    }
}