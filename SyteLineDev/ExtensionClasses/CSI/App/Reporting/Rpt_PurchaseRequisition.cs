//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseRequisition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseRequisition : IRpt_PurchaseRequisition
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PurchaseRequisition(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseRequisitionSp(string PreqStat = null,
		string PPreqItemStat = null,
		int? PrintReqNotes = null,
		int? PrintLineNotes = null,
		int? ShowExternal = null,
		int? ShowInternal = null,
		string PreqNumStarting = null,
		string PreqNumEnding = null,
		int? PreqItemStarting = null,
		int? PreqItemEnding = null,
		DateTime? PreqItemDueDateStarting = null,
		DateTime? PreqItemDueDateEnding = null,
		int? PreqItemDueDateStartingOffset = null,
		int? PreqItemDueDateEndingOffset = null,
		string PreqItemVendNumStarting = null,
		string PreqItemVendNumEnding = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string pSite = null)
		{
			StringType _PreqStat = PreqStat;
			StringType _PPreqItemStat = PPreqItemStat;
			ListYesNoType _PrintReqNotes = PrintReqNotes;
			ListYesNoType _PrintLineNotes = PrintLineNotes;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _ShowInternal = ShowInternal;
			ReqNumType _PreqNumStarting = PreqNumStarting;
			ReqNumType _PreqNumEnding = PreqNumEnding;
			ReqLineType _PreqItemStarting = PreqItemStarting;
			ReqLineType _PreqItemEnding = PreqItemEnding;
			DateType _PreqItemDueDateStarting = PreqItemDueDateStarting;
			DateType _PreqItemDueDateEnding = PreqItemDueDateEnding;
			DateOffsetType _PreqItemDueDateStartingOffset = PreqItemDueDateStartingOffset;
			DateOffsetType _PreqItemDueDateEndingOffset = PreqItemDueDateEndingOffset;
			VendNumType _PreqItemVendNumStarting = PreqItemVendNumStarting;
			VendNumType _PreqItemVendNumEnding = PreqItemVendNumEnding;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseRequisitionSp";
				
				appDB.AddCommandParameter(cmd, "PreqStat", _PreqStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPreqItemStat", _PPreqItemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReqNotes", _PrintReqNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineNotes", _PrintLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqNumStarting", _PreqNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqNumEnding", _PreqNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemStarting", _PreqItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemEnding", _PreqItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemDueDateStarting", _PreqItemDueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemDueDateEnding", _PreqItemDueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemDueDateStartingOffset", _PreqItemDueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemDueDateEndingOffset", _PreqItemDueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemVendNumStarting", _PreqItemVendNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqItemVendNumEnding", _PreqItemVendNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
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
