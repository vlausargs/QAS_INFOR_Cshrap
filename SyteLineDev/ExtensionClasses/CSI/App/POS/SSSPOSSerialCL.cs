//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSSerialCL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSSerialCL
    {
        DataTable SSSPOSSerialCLSp(string Item,
                                   string Whse,
                                   string Loc,
                                   string Lot,
                                   string POSNum,
                                   int? TransNum,
                                   decimal? QtyShipConv,
                                   string SerNum);
    }

    public class SSSPOSSerialCL : ISSSPOSSerialCL
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSPOSSerialCL(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSPOSSerialCLSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          string POSNum,
                                          int? TransNum,
                                          decimal? QtyShipConv,
                                          string SerNum)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                ItemType _Item = Item;
                WhseType _Whse = Whse;
                LocType _Loc = Loc;
                LotType _Lot = Lot;
                POSMNumType _POSNum = POSNum;
                POSMTransNumType _TransNum = TransNum;
                QtyUnitType _QtyShipConv = QtyShipConv;
                SerNumType _SerNum = SerNum;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSSPOSSerialCLSp";

                    appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "QtyShipConv", _QtyShipConv, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
