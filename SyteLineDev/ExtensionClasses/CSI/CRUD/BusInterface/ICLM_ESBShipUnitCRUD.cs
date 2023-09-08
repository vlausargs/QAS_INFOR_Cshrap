//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipUnitCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
    public interface ICLM_ESBShipUnitCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        ICollectionLoadResponse EsbshipunitviewSelect(int? ShipmentID);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ESBShipUnitSp(string AltExtGenSp, int? ShipmentID, string ShipmentStatus=null);
    }
}