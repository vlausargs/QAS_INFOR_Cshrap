//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TotalInventoryValuebyAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TotalInventoryValuebyAcct : IRpt_TotalInventoryValuebyAcct
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TotalInventoryValuebyAcct(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TotalInventoryValuebyAcctSp(string AccountStarting = null,
		string AccountEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string MaterialStatus = null,
		string MaterialType = null,
		string Source = null,
		string ABCCode = null,
		int? AcctUnit1 = null,
		int? AcctUnit2 = null,
		int? AcctUnit3 = null,
		int? AcctUnit4 = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			HighLowCharType _AccountStarting = AccountStarting;
			HighLowCharType _AccountEnding = AccountEnding;
			HighLowCharType _WhseStarting = WhseStarting;
			HighLowCharType _WhseEnding = WhseEnding;
			HighLowCharType _LocStarting = LocStarting;
			HighLowCharType _LocEnding = LocEnding;
			HighLowCharType _ProductCodeStarting = ProductCodeStarting;
			HighLowCharType _ProductCodeEnding = ProductCodeEnding;
			HighLowCharType _ItemStarting = ItemStarting;
			HighLowCharType _ItemEnding = ItemEnding;
			LongListType _MaterialStatus = MaterialStatus;
			LongListType _MaterialType = MaterialType;
			LongListType _Source = Source;
			LongListType _ABCCode = ABCCode;
			FlagNyType _AcctUnit1 = AcctUnit1;
			FlagNyType _AcctUnit2 = AcctUnit2;
			FlagNyType _AcctUnit3 = AcctUnit3;
			FlagNyType _AcctUnit4 = AcctUnit4;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TotalInventoryValuebyAcctSp";
				
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialStatus", _MaterialStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
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
