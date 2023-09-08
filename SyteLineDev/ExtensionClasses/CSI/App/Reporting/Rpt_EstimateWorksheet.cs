//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateWorksheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_EstimateWorksheet : IRpt_EstimateWorksheet
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EstimateWorksheet(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateWorksheetSp(string EstimateStatus = "WQPH",
		string EstimateStarting = null,
		string EstimateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? QuoteDateStarting = null,
		DateTime? QuoteDateEnding = null,
		int? QuoteDateStartingOffset = null,
		int? QuoteDateEndingOffset = null,
		DateTime? ExpireDateStarting = null,
		DateTime? ExpireDateEnding = null,
		int? ExpireDateStartingOffset = null,
		int? ExpireDateEndingOffset = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustItemStarting = null,
		string CustItemEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? CoitemShowInternal = 1,
		int? CoitemShowExternal = 1,
		int? DisplayHeader = 0,
		string StartProspect = null,
		string EndProspect = null,
		string pSite = null)
		{
			StringType _EstimateStatus = EstimateStatus;
			CoNumType _EstimateStarting = EstimateStarting;
			CoNumType _EstimateEnding = EstimateEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			GenericDateType _QuoteDateStarting = QuoteDateStarting;
			GenericDateType _QuoteDateEnding = QuoteDateEnding;
			DateOffsetType _QuoteDateStartingOffset = QuoteDateStartingOffset;
			DateOffsetType _QuoteDateEndingOffset = QuoteDateEndingOffset;
			GenericDateType _ExpireDateStarting = ExpireDateStarting;
			GenericDateType _ExpireDateEnding = ExpireDateEnding;
			DateOffsetType _ExpireDateStartingOffset = ExpireDateStartingOffset;
			DateOffsetType _ExpireDateEndingOffset = ExpireDateEndingOffset;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			CustItemType _CustItemStarting = CustItemStarting;
			CustItemType _CustItemEnding = CustItemEnding;
			GenericDateType _DueDateStarting = DueDateStarting;
			GenericDateType _DueDateEnding = DueDateEnding;
			DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
			DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
			FlagNyType _CoitemShowInternal = CoitemShowInternal;
			FlagNyType _CoitemShowExternal = CoitemShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ProspectIDType _StartProspect = StartProspect;
			ProspectIDType _EndProspect = EndProspect;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EstimateWorksheetSp";
				
				appDB.AddCommandParameter(cmd, "EstimateStatus", _EstimateStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateStarting", _EstimateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateEnding", _EstimateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateStarting", _QuoteDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateEnding", _QuoteDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateStartingOffset", _QuoteDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateEndingOffset", _QuoteDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateStarting", _ExpireDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateEnding", _ExpireDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateStartingOffset", _ExpireDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateEndingOffset", _ExpireDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemStarting", _CustItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItemEnding", _CustItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemShowInternal", _CoitemShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemShowExternal", _CoitemShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProspect", _StartProspect, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProspect", _EndProspect, ParameterDirection.Input);
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
