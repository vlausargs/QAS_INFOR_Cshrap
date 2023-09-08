//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemRevision.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ItemRevision : IRpt_ItemRevision
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemRevision(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemRevisionSp(string ItemStarting = null,
		string ItemEnding = null,
		string RevisionStarting = null,
		string RevisionEnding = null,
		string ProdCodeStarting = null,
		string ProdCodeEnding = null,
		string ExOptacAbcCode = null,
		int? OperNumStarting = null,
		int? OperNumEnding = null,
		int? ECNNumStarting = null,
		int? ECNNumEnding = null,
		int? PJobRefs = null,
		int? PItemManufacture = null,
		int? PECNItem = null,
		int? HighlightRevDiff = null,
		int? PJobrouteNote = null,
		int? PJobmatlNote = null,
		int? PECNItemNote = null,
		int? PageOper = null,
		int? ExOptacChkEffDates = null,
		DateTime? ExOptdfEffDate = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? ExOptdfEffDateOffset = null,
		string SummaryDetail = null,
		string SiteGroup = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			RevisionType _RevisionStarting = RevisionStarting;
			RevisionType _RevisionEnding = RevisionEnding;
			ProductCodeType _ProdCodeStarting = ProdCodeStarting;
			ProductCodeType _ProdCodeEnding = ProdCodeEnding;
			StringType _ExOptacAbcCode = ExOptacAbcCode;
			OperNumType _OperNumStarting = OperNumStarting;
			OperNumType _OperNumEnding = OperNumEnding;
			EcnNumType _ECNNumStarting = ECNNumStarting;
			EcnNumType _ECNNumEnding = ECNNumEnding;
			FlagNyType _PJobRefs = PJobRefs;
			FlagNyType _PItemManufacture = PItemManufacture;
			FlagNyType _PECNItem = PECNItem;
			FlagNyType _HighlightRevDiff = HighlightRevDiff;
			FlagNyType _PJobrouteNote = PJobrouteNote;
			FlagNyType _PJobmatlNote = PJobmatlNote;
			FlagNyType _PECNItemNote = PECNItemNote;
			ListYesNoType _PageOper = PageOper;
			ListYesNoType _ExOptacChkEffDates = ExOptacChkEffDates;
			DateType _ExOptdfEffDate = ExOptdfEffDate;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			DateOffsetType _ExOptdfEffDateOffset = ExOptdfEffDateOffset;
			StringType _SummaryDetail = SummaryDetail;
			SiteGroupType _SiteGroup = SiteGroup;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemRevisionSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionStarting", _RevisionStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionEnding", _RevisionEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdCodeStarting", _ProdCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdCodeEnding", _ProdCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacAbcCode", _ExOptacAbcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNumStarting", _OperNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNumEnding", _OperNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNNumStarting", _ECNNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNNumEnding", _ECNNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobRefs", _PJobRefs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemManufacture", _PItemManufacture, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PECNItem", _PECNItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HighlightRevDiff", _HighlightRevDiff, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobrouteNote", _PJobrouteNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlNote", _PJobmatlNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PECNItemNote", _PECNItemNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageOper", _PageOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacChkEffDates", _ExOptacChkEffDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEffDate", _ExOptdfEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEffDateOffset", _ExOptdfEffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummaryDetail", _SummaryDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
