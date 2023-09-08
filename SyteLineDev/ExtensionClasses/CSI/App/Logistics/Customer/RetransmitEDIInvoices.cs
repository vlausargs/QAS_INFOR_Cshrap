//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEDIInvoices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IRetransmitEDIInvoices
    {
        (int? ReturnCode, string Infobar) RetransmitEDIInvoicesSp(string CustomerStarting = null,
        string CustomerEnding = null,
        string InvNumStarting = null,
        string InvNumEnding = null,
        DateTime? CDateStarting = null,
        DateTime? CDateEnding = null,
        short? CDateStartingOffset = null,
        short? CDateEndingOffset = null,
        byte? ProcessFlag = (byte)1,
        string Infobar = null);
    }

    public class RetransmitEDIInvoices : IRetransmitEDIInvoices
    {
        readonly IApplicationDB appDB;

        public RetransmitEDIInvoices(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) RetransmitEDIInvoicesSp(string CustomerStarting = null,
        string CustomerEnding = null,
        string InvNumStarting = null,
        string InvNumEnding = null,
        DateTime? CDateStarting = null,
        DateTime? CDateEnding = null,
        short? CDateStartingOffset = null,
        short? CDateEndingOffset = null,
        byte? ProcessFlag = (byte)1,
        string Infobar = null)
        {
            CustNumType _CustomerStarting = CustomerStarting;
            CustNumType _CustomerEnding = CustomerEnding;
            InvNumType _InvNumStarting = InvNumStarting;
            InvNumType _InvNumEnding = InvNumEnding;
            DateType _CDateStarting = CDateStarting;
            DateType _CDateEnding = CDateEnding;
            DateOffsetType _CDateStartingOffset = CDateStartingOffset;
            DateOffsetType _CDateEndingOffset = CDateEndingOffset;
            ListYesNoType _ProcessFlag = ProcessFlag;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetransmitEDIInvoicesSp";

                appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
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
