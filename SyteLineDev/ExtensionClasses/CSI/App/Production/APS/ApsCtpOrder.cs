//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpOrder
    {
        int ApsCtpOrderSp(CoNumType PCoNum,
                          ListYesNoType PShipPartial,
                          ref DateTimeType PProjDate);
    }

    public class ApsCtpOrder : IApsCtpOrder
    {
        readonly IApplicationDB appDB;

        public ApsCtpOrder(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpOrderSp(CoNumType PCoNum,
                                 ListYesNoType PShipPartial,
                                 ref DateTimeType PProjDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpOrderSp";

                appDB.AddCommandParameter(cmd, "PCoNum", PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PShipPartial", PShipPartial, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PProjDate", PProjDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
