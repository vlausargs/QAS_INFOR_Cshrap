//PROJECT NAME: Logistics.Customer
//CLASS NAME: ProcessShipmentProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ProcessShipmentProcess : IProcessShipmentProcess
    {
        readonly IApplicationDB appDB;


        public ProcessShipmentProcess(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) ProcessShipmentProcessSp(Guid? TCoNumRowPointer,
        Guid? TCustAddrRowPointer,
        int? CreditHoldChanged,
        Guid? TrnRowPointer,
        string Infobar)
        {
            RowPointerType _TCoNumRowPointer = TCoNumRowPointer;
            RowPointerType _TCustAddrRowPointer = TCustAddrRowPointer;
            IntType _CreditHoldChanged = CreditHoldChanged;
            RowPointerType _TrnRowPointer = TrnRowPointer;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProcessShipmentProcessSp";

                appDB.AddCommandParameter(cmd, "TCoNumRowPointer", _TCoNumRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TCustAddrRowPointer", _TCustAddrRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreditHoldChanged", _CreditHoldChanged, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrnRowPointer", _TrnRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
