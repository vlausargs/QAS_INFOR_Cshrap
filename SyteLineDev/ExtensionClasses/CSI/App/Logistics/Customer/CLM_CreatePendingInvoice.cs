//PROJECT NAME: Logistics
//CLASS NAME: CLM_CreatePendingInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_CreatePendingInvoice : ICLM_CreatePendingInvoice
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CreatePendingInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CreatePendingInvoiceSp(Guid? PProcessID,
		string PCustNum = null,
		string FormType = null,
		int? NonDraftCust = null,
		string PType = "I",
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				RowPointerType _PProcessID = PProcessID;
				CustNumType _PCustNum = PCustNum;
				StringType _FormType = FormType;
				ListYesNoType _NonDraftCust = NonDraftCust;
				InvoiceTypeType _PType = PType;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_CreatePendingInvoiceSp";
					
					appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FormType", _FormType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NonDraftCust", _NonDraftCust, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
