//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpUomConvQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpUomConvQty
    {
        int ApsCtpUomConvQtySp(QtyUnitType QtyToBeConverted,
                               UMType UM,
                               ItemType Item,
                               StringType FROMBase,
                               ref QtyUnitType ConvertedQty);
    }

    public class ApsCtpUomConvQty : IApsCtpUomConvQty
    {
        readonly IApplicationDB appDB;

        public ApsCtpUomConvQty(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpUomConvQtySp(QtyUnitType QtyToBeConverted,
                                      UMType UM,
                                      ItemType Item,
                                      StringType FROMBase,
                                      ref QtyUnitType ConvertedQty)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpUomConvQtySp";

                appDB.AddCommandParameter(cmd, "QtyToBeConverted", QtyToBeConverted, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FROMBase", FROMBase, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConvertedQty", ConvertedQty, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
