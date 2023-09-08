//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEdiAck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IRetransmitEdiAck
    {
        (int? ReturnCode, string Infobar) RetransmitEdiAckSp(string CoNumStarting = null,
        string CoNumEnding = null,
        string CustomerStarting = null,
        string CustomerEnding = null,
        DateTime? CDateStarting = null,
        DateTime? CDateEnding = null,
        short? CDateStartingOffset = null,
        short? CDateEndingOffset = null,
        byte? ProcessFlag = (byte)1,
        string Infobar = null);
    }

    public class RetransmitEdiAck : IRetransmitEdiAck
    {
        readonly IApplicationDB appDB;

        public RetransmitEdiAck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) RetransmitEdiAckSp(string CoNumStarting = null,
        string CoNumEnding = null,
        string CustomerStarting = null,
        string CustomerEnding = null,
        DateTime? CDateStarting = null,
        DateTime? CDateEnding = null,
        short? CDateStartingOffset = null,
        short? CDateEndingOffset = null,
        byte? ProcessFlag = (byte)1,
        string Infobar = null)
        {
            CoNumType _CoNumStarting = CoNumStarting;
            CoNumType _CoNumEnding = CoNumEnding;
            CustNumType _CustomerStarting = CustomerStarting;
            CustNumType _CustomerEnding = CustomerEnding;
            DateType _CDateStarting = CDateStarting;
            DateType _CDateEnding = CDateEnding;
            DateOffsetType _CDateStartingOffset = CDateStartingOffset;
            DateOffsetType _CDateEndingOffset = CDateEndingOffset;
            ListYesNoType _ProcessFlag = ProcessFlag;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetransmitEdiAckSp";

                appDB.AddCommandParameter(cmd, "CoNumStarting", _CoNumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNumEnding", _CoNumEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateStarting", _CDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateEnding", _CDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateStartingOffset", _CDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CDateEndingOffset", _CDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessFlag", _ProcessFlag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
