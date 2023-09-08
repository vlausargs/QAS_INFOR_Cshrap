//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedRescheduleLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedRescheduleLoad : ISSSFSSchedRescheduleLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSchedRescheduleLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSSchedRescheduleLoadSp(string RowPointers,
		string PartnerID,
		decimal? MoveAmount,
		string MoveUnit,
		int? SchedMethod,
		string ApptStat,
		int? UseMaxHrs,
		int? UseProfileEndOfDay)
		{
			StringType _RowPointers = RowPointers;
			FSPartnerType _PartnerID = PartnerID;
			QtyUnitType _MoveAmount = MoveAmount;
			FSDurationTypeType _MoveUnit = MoveUnit;
			ListYesNoType _SchedMethod = SchedMethod;
			FSApptStatType _ApptStat = ApptStat;
			ListYesNoType _UseMaxHrs = UseMaxHrs;
			ListYesNoType _UseProfileEndOfDay = UseProfileEndOfDay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedRescheduleLoadSp";
				
				appDB.AddCommandParameter(cmd, "RowPointers", _RowPointers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveAmount", _MoveAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveUnit", _MoveUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedMethod", _SchedMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptStat", _ApptStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseMaxHrs", _UseMaxHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseProfileEndOfDay", _UseProfileEndOfDay, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
