//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetEvents.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetEvents : ICLM_SchedGetEvents
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_SchedGetEvents(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetEventsSp(string Username,
		string ProfileUsername,
		string ScheduleID,
		string FilterUsername,
		string FilterName,
		int? FilterType,
		int? ColorCoding,
		DateTime? StartDate,
		DateTime? EndDate,
		int? PartnerFilterOverride,
		string SelectedPartnerList,
		int? TaskFilterOverride,
		string SelectedTaskList,
		int? View = 0,
		int? RecordCap = 200)
		{
			StringType _Username = Username;
			StringType _ProfileUsername = ProfileUsername;
			StringType _ScheduleID = ScheduleID;
			StringType _FilterUsername = FilterUsername;
			StringType _FilterName = FilterName;
			IntType _FilterType = FilterType;
			IntType _ColorCoding = ColorCoding;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			ShortType _PartnerFilterOverride = PartnerFilterOverride;
			LongListType _SelectedPartnerList = SelectedPartnerList;
			ShortType _TaskFilterOverride = TaskFilterOverride;
			LongListType _SelectedTaskList = SelectedTaskList;
			ShortType _View = View;
			IntType _RecordCap = RecordCap;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_SchedGetEventsSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProfileUsername", _ProfileUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleID", _ScheduleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterUsername", _FilterUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterName", _FilterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterType", _FilterType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColorCoding", _ColorCoding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerFilterOverride", _PartnerFilterOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedPartnerList", _SelectedPartnerList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskFilterOverride", _TaskFilterOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedTaskList", _SelectedTaskList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "View", _View, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordCap", _RecordCap, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
