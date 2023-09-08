//PROJECT NAME: Reporting
//CLASS NAME: THARpt_InventoryBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_InventoryBalance : ITHARpt_InventoryBalance
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_InventoryBalance(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_InventoryBalanceSp(string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string ReasonCodeStarting = null,
		string ReasonCodeEnding = null,
		int? SummaryDtl = 0,
		int? OneItmPerPg = null,
		int? IncludeMoveTrn = null,
		int? IncludeNonNetStk = null,
		int? DisplayHeader = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		string pSite = null,
		string MessageLanguage = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null)
		{
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			LocType _LocStarting = LocStarting;
			LocType _LocEnding = LocEnding;
			DateTimeType _TransDateStarting = TransDateStarting;
			DateTimeType _TransDateEnding = TransDateEnding;
			ReasonCodeType _ReasonCodeStarting = ReasonCodeStarting;
			ReasonCodeType _ReasonCodeEnding = ReasonCodeEnding;
			ListYesNoType _SummaryDtl = SummaryDtl;
			ListYesNoType _OneItmPerPg = OneItmPerPg;
			ListYesNoType _IncludeMoveTrn = IncludeMoveTrn;
			ListYesNoType _IncludeNonNetStk = IncludeNonNetStk;
			ListYesNoType _DisplayHeader = DisplayHeader;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			SiteType _pSite = pSite;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_InventoryBalanceSp";
				
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCodeStarting", _ReasonCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCodeEnding", _ReasonCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummaryDtl", _SummaryDtl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OneItmPerPg", _OneItmPerPg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeMoveTrn", _IncludeMoveTrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeNonNetStk", _IncludeNonNetStk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
