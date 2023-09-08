//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateCONumStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IValidateCONumStatus
    {
        int ValidateCONumStatusSp(string PCONum,
                                  string PCOLineStatus,
                                  ref byte? Consignment,
                                  ref string ConsignmentWarehouse,
                                  ref string Infobar);
    }

    public class ValidateCONumStatus : IValidateCONumStatus
    {
        readonly IApplicationDB appDB;

        public ValidateCONumStatus(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateCONumStatusSp(string PCONum,
                                         string PCOLineStatus,
                                         ref byte? Consignment,
                                         ref string ConsignmentWarehouse,
                                         ref string Infobar)
        {
            CoNumType _PCONum = PCONum;
            InfobarType _PCOLineStatus = PCOLineStatus;
            ListYesNoType _Consignment = Consignment;
            WhseType _ConsignmentWarehouse = ConsignmentWarehouse;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateCONumStatusSp";

                appDB.AddCommandParameter(cmd, "PCONum", _PCONum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCOLineStatus", _PCOLineStatus, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Consignment", _Consignment, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ConsignmentWarehouse", _ConsignmentWarehouse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Consignment = _Consignment;
                ConsignmentWarehouse = _ConsignmentWarehouse;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
