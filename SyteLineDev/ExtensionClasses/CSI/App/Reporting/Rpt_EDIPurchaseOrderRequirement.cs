//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EDIPurchaseOrderRequirement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EDIPurchaseOrderRequirement
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EDIPurchaseOrderRequirementSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? ReceiveDateStarting = null,
		DateTime? ReceiveDateEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string TransactionCode = null,
		string SummaryOrDetail = null,
		short? ReceiveDateStartingOffset = null,
		short? ReceiveDateEndingOffset = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_EDIPurchaseOrderRequirement : IRpt_EDIPurchaseOrderRequirement
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EDIPurchaseOrderRequirement(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EDIPurchaseOrderRequirementSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? ReceiveDateStarting = null,
		DateTime? ReceiveDateEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string TransactionCode = null,
		string SummaryOrDetail = null,
		short? ReceiveDateStartingOffset = null,
		short? ReceiveDateEndingOffset = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _ReceiveDateStarting = ReceiveDateStarting;
			DateType _ReceiveDateEnding = ReceiveDateEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			EdiTrxCodeType _TransactionCode = TransactionCode;
			InfobarType _SummaryOrDetail = SummaryOrDetail;
			DateOffsetType _ReceiveDateStartingOffset = ReceiveDateStartingOffset;
			DateOffsetType _ReceiveDateEndingOffset = ReceiveDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EDIPurchaseOrderRequirementSp";
				
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiveDateStarting", _ReceiveDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiveDateEnding", _ReceiveDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionCode", _TransactionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummaryOrDetail", _SummaryOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiveDateStartingOffset", _ReceiveDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiveDateEndingOffset", _ReceiveDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
