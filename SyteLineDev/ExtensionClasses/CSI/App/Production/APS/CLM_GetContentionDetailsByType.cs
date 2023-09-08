//PROJECT NAME: Production
//CLASS NAME: CLM_GetContentionDetailsByType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_GetContentionDetailsByType : ICLM_GetContentionDetailsByType
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetContentionDetailsByType(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetContentionDetailsByTypeSp(string Group,
		DateTime? StartDate,
		DateTime? EndDate,
		int? AltNo,
		string DisplayType,
		int? RecordCap,
		int? Interval,
		string Period,
		string GroupType,
		int? ExcludeInfinite,
		string WildCardChar)
		{
			ApsResgroupType _Group = Group;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			ApsAltNoType _AltNo = AltNo;
			StringType _DisplayType = DisplayType;
			IntType _RecordCap = RecordCap;
			IntType _Interval = Interval;
			StringType _Period = Period;
			StringType _GroupType = GroupType;
			IntType _ExcludeInfinite = ExcludeInfinite;
			StringType _WildCardChar = WildCardChar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetContentionDetailsByTypeSp";
				
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayType", _DisplayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordCap", _RecordCap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Interval", _Interval, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupType", _GroupType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeInfinite", _ExcludeInfinite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WildCardChar", _WildCardChar, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
