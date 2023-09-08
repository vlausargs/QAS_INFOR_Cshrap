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
    public interface ICLM_RetransmitEDIInvoices
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_RetransmitEDIInvoicesSp(string CustomerStarting = null,
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

    public class CLM_RetransmitEDIInvoices : ICLM_RetransmitEDIInvoices
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public CLM_RetransmitEDIInvoices(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_RetransmitEDIInvoicesSp(string CustomerStarting = null,
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
            bunchedLoadCollection.StartBunching();

            try
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
                    DataTable dtReturn = new DataTable();

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

                    IntType returnVal = 0;
                    IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                    dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
