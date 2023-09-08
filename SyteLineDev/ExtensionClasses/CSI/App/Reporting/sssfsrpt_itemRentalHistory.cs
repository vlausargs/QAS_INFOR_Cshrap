//PROJECT NAME: Reporting
//CLASS NAME: sssfsrpt_itemRentalHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class sssfsrpt_itemRentalHistory : Isssfsrpt_itemRentalHistory
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public sssfsrpt_itemRentalHistory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) sssfsrpt_itemRentalHistorySp(string ItemStarting = null,
		string ItemEnding = null,
		string SerNumStarting = null,
		string SerNumEnding = null,
		string CustNumStarting = null,
		string CustNumEnding = null,
		string ContractStarting = null,
		string ContractEnding = null,
		DateTime? InvDateStarting = null,
		DateTime? InvDateEnding = null,
		DateTime? StartDateStarting = null,
		DateTime? StartDateEnding = null,
		int? IncOpenContract = 1,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			SerNumType _SerNumStarting = SerNumStarting;
			SerNumType _SerNumEnding = SerNumEnding;
			CustNumType _CustNumStarting = CustNumStarting;
			CustNumType _CustNumEnding = CustNumEnding;
			FSContractType _ContractStarting = ContractStarting;
			FSContractType _ContractEnding = ContractEnding;
			DateType _InvDateStarting = InvDateStarting;
			DateType _InvDateEnding = InvDateEnding;
			DateTimeType _StartDateStarting = StartDateStarting;
			DateTimeType _StartDateEnding = StartDateEnding;
			ListYesNoType _IncOpenContract = IncOpenContract;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "sssfsrpt_itemRentalHistorySp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumStarting", _SerNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNumEnding", _SerNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumStarting", _CustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumEnding", _CustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractStarting", _ContractStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractEnding", _ContractEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDateStarting", _InvDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDateEnding", _InvDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateStarting", _StartDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateEnding", _StartDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncOpenContract", _IncOpenContract, ParameterDirection.Input);
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
