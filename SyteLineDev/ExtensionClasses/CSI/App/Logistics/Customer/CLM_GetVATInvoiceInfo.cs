//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetVATInvoiceInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetVATInvoiceInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetVATInvoiceInfoSp(string CustNumStarting,
		string CustNumEnding,
		string CoNumStarting,
		string CoNumEnding,
		string InvNumStarting,
		string InvNumEnding,
		DateTime? InvDateStarting,
		DateTime? InvDateEnding,
		string FileType,
		string CurrCode);
	}
	
	public class CLM_GetVATInvoiceInfo : ICLM_GetVATInvoiceInfo
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetVATInvoiceInfo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetVATInvoiceInfoSp(string CustNumStarting,
		string CustNumEnding,
		string CoNumStarting,
		string CoNumEnding,
		string InvNumStarting,
		string InvNumEnding,
		DateTime? InvDateStarting,
		DateTime? InvDateEnding,
		string FileType,
		string CurrCode)
		{
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			CoNumType _CoNumStarting = CoNumStarting;
			CoNumType _CoNumEnding = CoNumEnding;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			DateType _InvDateStarting = InvDateStarting;
			DateType _InvDateEnding = InvDateEnding;
			StringType _FileType = FileType;
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetVATInvoiceInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNumStarting", _CoNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNumEnding", _CoNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDateStarting", _InvDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDateEnding", _InvDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileType", _FileType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
