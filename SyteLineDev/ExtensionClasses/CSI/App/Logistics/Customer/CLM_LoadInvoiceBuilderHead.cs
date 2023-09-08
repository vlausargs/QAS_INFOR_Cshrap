//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_LoadInvoiceBuilderHead.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_LoadInvoiceBuilderHead
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LoadInvoiceBuilderHeadSp(string PCustNum,
		string FormType,
		byte? NonDraftCust,
		string FilterString = null);
	}
	
	public class CLM_LoadInvoiceBuilderHead : ICLM_LoadInvoiceBuilderHead
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_LoadInvoiceBuilderHead(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_LoadInvoiceBuilderHeadSp(string PCustNum,
		string FormType,
		byte? NonDraftCust,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _PCustNum = PCustNum;
				StringType _FormType = FormType;
				ListYesNoType _NonDraftCust = NonDraftCust;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_LoadInvoiceBuilderHeadSp";
					
					appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FormType", _FormType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NonDraftCust", _NonDraftCust, ParameterDirection.Input);
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
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
