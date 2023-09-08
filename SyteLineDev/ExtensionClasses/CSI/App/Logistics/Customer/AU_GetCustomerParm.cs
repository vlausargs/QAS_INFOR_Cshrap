//PROJECT NAME: CSICustomer
//CLASS NAME: AU_GetCustomerParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IAU_GetCustomerParm
    {
        int AU_GetCustomerParmSp(CustNumType CustNum,
                                 ref ListOrderDueType CustPriceBy);
    }

    public class AU_GetCustomerParm : IAU_GetCustomerParm
    {
        readonly IApplicationDB appDB;

        public AU_GetCustomerParm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_GetCustomerParmSp(CustNumType CustNum,
                                        ref ListOrderDueType CustPriceBy)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_GetCustomerParmSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustPriceBy", CustPriceBy, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
