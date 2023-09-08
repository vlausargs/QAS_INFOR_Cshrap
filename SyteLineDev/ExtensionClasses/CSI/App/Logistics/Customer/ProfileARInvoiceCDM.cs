//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileARInvoiceCDM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IProfileARInvoiceCDM
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileARInvoiceCDMSp(byte? PrePrint = null,
		string DocType = null,
		string StartCustomer = null,
		string EndCustomer = null,
		string StartInvoice = null,
		string EndInvoice = null,
		int? StartChkRef = null,
		int? EndChkRef = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		DateTime? StartIssueDate = null,
		DateTime? EndIssueDate = null,
		short? StartInvDateOffset = null,
		short? EndInvDateOffset = null,
		short? StartIssueDateOffset = null,
		short? EndIssueDateOffset = null);
	}
	
	public class ProfileARInvoiceCDM : IProfileARInvoiceCDM
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileARInvoiceCDM(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileARInvoiceCDMSp(byte? PrePrint = null,
		string DocType = null,
		string StartCustomer = null,
		string EndCustomer = null,
		string StartInvoice = null,
		string EndInvoice = null,
		int? StartChkRef = null,
		int? EndChkRef = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		DateTime? StartIssueDate = null,
		DateTime? EndIssueDate = null,
		short? StartInvDateOffset = null,
		short? EndInvDateOffset = null,
		short? StartIssueDateOffset = null,
		short? EndIssueDateOffset = null)
		{
			ListYesNoType _PrePrint = PrePrint;
			InfobarType _DocType = DocType;
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			InvNumType _StartInvoice = StartInvoice;
			InvNumType _EndInvoice = EndInvoice;
			ArInvSeqType _StartChkRef = StartChkRef;
			ArInvSeqType _EndChkRef = EndChkRef;
			GenericDateType _StartInvDate = StartInvDate;
			GenericDateType _EndInvDate = EndInvDate;
			GenericDateType _StartIssueDate = StartIssueDate;
			GenericDateType _EndIssueDate = EndIssueDate;
			DateOffsetType _StartInvDateOffset = StartInvDateOffset;
			DateOffsetType _EndInvDateOffset = EndInvDateOffset;
			DateOffsetType _StartIssueDateOffset = StartIssueDateOffset;
			DateOffsetType _EndIssueDateOffset = EndIssueDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileARInvoiceCDMSp";
				
				appDB.AddCommandParameter(cmd, "PrePrint", _PrePrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocType", _DocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvoice", _StartInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvoice", _EndInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartChkRef", _StartChkRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndChkRef", _EndChkRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartIssueDate", _StartIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndIssueDate", _EndIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDateOffset", _StartInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDateOffset", _EndInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartIssueDateOffset", _StartIssueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndIssueDateOffset", _EndIssueDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
