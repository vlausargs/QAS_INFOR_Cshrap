//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleEarnedCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleEarnedCost : IRpt_ProductionScheduleEarnedCost
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductionScheduleEarnedCost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleEarnedCostSp(DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string ScheduleIdStarting = null,
		string ScheduleIdEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		int? PrintCost = 0,
		string pSite = null)
		{
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
			PsNumType _ScheduleIdStarting = ScheduleIdStarting;
			PsNumType _ScheduleIdEnding = ScheduleIdEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			ListYesNoType _PrintCost = PrintCost;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionScheduleEarnedCostSp";
				
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleIdStarting", _ScheduleIdStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleIdEnding", _ScheduleIdEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
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
