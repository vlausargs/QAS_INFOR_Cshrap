//PROJECT NAME: CSICustomer
//CLASS NAME: CustomerServiceAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICustomerServiceAlerts
    {
        int CustomerServiceAlertsSp(ref NumberOfLinesType PastDueCOLines,
                                    ref NumberOfLinesType PastDueCOReleases,
                                    ref NumberOfLinesType EstimatesToExpire,
                                    ref NumberOfLinesType NumberOfUserTasks,
                                    ref NumberOfLinesType NumberOfEventMessages);
    }

    public class CustomerServiceAlerts : ICustomerServiceAlerts
    {
        readonly IApplicationDB appDB;

        public CustomerServiceAlerts(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CustomerServiceAlertsSp(ref NumberOfLinesType PastDueCOLines,
                                           ref NumberOfLinesType PastDueCOReleases,
                                           ref NumberOfLinesType EstimatesToExpire,
                                           ref NumberOfLinesType NumberOfUserTasks,
                                           ref NumberOfLinesType NumberOfEventMessages)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustomerServiceAlertsSp";

                appDB.AddCommandParameter(cmd, "PastDueCOLines", PastDueCOLines, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PastDueCOReleases", PastDueCOReleases, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EstimatesToExpire", EstimatesToExpire, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NumberOfUserTasks", NumberOfUserTasks, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NumberOfEventMessages", NumberOfEventMessages, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
