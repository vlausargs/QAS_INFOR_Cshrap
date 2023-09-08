//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCustProfileExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEdiCustProfileExists
    {
        int EdiCustProfileExistsSp(string PCustNum,
                                   int? PCustSeq,
                                   ref byte? PProfileExists,
                                   ref byte? PGenInv);
    }

    public class EdiCustProfileExists : IEdiCustProfileExists
    {
        readonly IApplicationDB appDB;

        public EdiCustProfileExists(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EdiCustProfileExistsSp(string PCustNum,
                                          int? PCustSeq,
                                          ref byte? PProfileExists,
                                          ref byte? PGenInv)
        {
            CustNumType _PCustNum = PCustNum;
            CustSeqType _PCustSeq = PCustSeq;
            ListYesNoType _PProfileExists = PProfileExists;
            ListYesNoType _PGenInv = PGenInv;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EdiCustProfileExistsSp";

                appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PProfileExists", _PProfileExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PGenInv", _PGenInv, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PProfileExists = _PProfileExists;
                PGenInv = _PGenInv;

                return Severity;
            }
        }
    }
}
