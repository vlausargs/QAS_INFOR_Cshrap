//PROJECT NAME: Reporting
//CLASS NAME: THARpt_StockBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_StockBalance : ITHARpt_StockBalance
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_StockBalance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_StockBalanceSp(DateTime? pStartDate = null,
		DateTime? pEndDate = null,
		string pStartItem = null,
		string pEndItem = null,
		string pWhseStarting = null,
		string pWhseEnding = null,
		string pLocStarting = null,
		string pLocEnding = null,
		int? pSumDtl = 0,
		string pSite = null)
		{
			DateType _pStartDate = pStartDate;
			DateType _pEndDate = pEndDate;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			WhseType _pWhseStarting = pWhseStarting;
			WhseType _pWhseEnding = pWhseEnding;
			LocType _pLocStarting = pLocStarting;
			LocType _pLocEnding = pLocEnding;
			ListYesNoType _pSumDtl = pSumDtl;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_StockBalanceSp";
				
				appDB.AddCommandParameter(cmd, "pStartDate", _pStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhseStarting", _pWhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhseEnding", _pWhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLocStarting", _pLocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLocEnding", _pLocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSumDtl", _pSumDtl, ParameterDirection.Input);
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
