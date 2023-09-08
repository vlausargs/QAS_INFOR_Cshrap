//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_Discrepancy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_Discrepancy : IRpt_RSQC_Discrepancy
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_Discrepancy(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_DiscrepancySp(
			string BegItem = null,
			string EndItem = null,
			string BegDisc = null,
			string EndDisc = null,
			int? BegRcvr = null,
			int? EndRcvr = null,
			DateTime? BegDate = null,
			DateTime? EndDate = null,
			string BegPO = null,
			string EndPO = null,
			string BegJob = null,
			string EndJob = null,
			string BegCO = null,
			string EndCO = null,
			string BegLot = null,
			string EndLot = null,
			string RefType = null,
			string SortBy = null,
			int? DiscOnly = null)
		{
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			StringType _BegDisc = BegDisc;
			StringType _EndDisc = EndDisc;
			IntType _BegRcvr = BegRcvr;
			IntType _EndRcvr = EndRcvr;
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			PoNumType _BegPO = BegPO;
			PoNumType _EndPO = EndPO;
			JobType _BegJob = BegJob;
			JobType _EndJob = EndJob;
			CoNumType _BegCO = BegCO;
			CoNumType _EndCO = EndCO;
			LotType _BegLot = BegLot;
			LotType _EndLot = EndLot;
			StringType _RefType = RefType;
			StringType _SortBy = SortBy;
			IntType _DiscOnly = DiscOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_DiscrepancySp";
				
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDisc", _BegDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDisc", _EndDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegRcvr", _BegRcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRcvr", _EndRcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPO", _BegPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPO", _EndPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegJob", _BegJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCO", _BegCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCO", _EndCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegLot", _BegLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLot", _EndLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscOnly", _DiscOnly, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
