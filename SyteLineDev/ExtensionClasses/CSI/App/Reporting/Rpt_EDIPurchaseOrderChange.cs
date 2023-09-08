//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EDIPurchaseOrderChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EDIPurchaseOrderChange
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EDIPurchaseOrderChangeSp(string StartCustomer = null,
		string EndCustomer = null,
		DateTime? StartReceiveDate = null,
		DateTime? EndReceiveDate = null,
		string StartOrder = null,
		string EndOrder = null,
		string TransactionCode = "POC",
		string SumOrDetail = "D",
		short? StartDateOffset = null,
		short? EndDateOffset = null,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_EDIPurchaseOrderChange : IRpt_EDIPurchaseOrderChange
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EDIPurchaseOrderChange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EDIPurchaseOrderChangeSp(string StartCustomer = null,
		string EndCustomer = null,
		DateTime? StartReceiveDate = null,
		DateTime? EndReceiveDate = null,
		string StartOrder = null,
		string EndOrder = null,
		string TransactionCode = "POC",
		string SumOrDetail = "D",
		short? StartDateOffset = null,
		short? EndDateOffset = null,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null)
		{
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			GenericDateType _StartReceiveDate = StartReceiveDate;
			GenericDateType _EndReceiveDate = EndReceiveDate;
			CoNumType _StartOrder = StartOrder;
			CoNumType _EndOrder = EndOrder;
			EdiTrxCodeType _TransactionCode = TransactionCode;
			Infobar _SumOrDetail = SumOrDetail;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EDIPurchaseOrderChangeSp";
				
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReceiveDate", _StartReceiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReceiveDate", _EndReceiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrder", _StartOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrder", _EndOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionCode", _TransactionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SumOrDetail", _SumOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
