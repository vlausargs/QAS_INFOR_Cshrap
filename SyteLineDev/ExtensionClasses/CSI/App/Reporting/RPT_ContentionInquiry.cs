//PROJECT NAME: Reporting
//CLASS NAME: RPT_ContentionInquiry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_ContentionInquiry : IRPT_ContentionInquiry
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_ContentionInquiry(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_ContentionInquirySP(
			string pSite,
			string Group,
			DateTime? StartDate,
			DateTime? EndDate,
			int? ALTNO,
			string DisplayType,
			int? RecordCap,
			int? Interval,
			string Period,
			string GroupType,
			int? ExcludeInfinite)
		{
			StringType _pSite = pSite;
			StringType _Group = Group;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			IntType _ALTNO = ALTNO;
			StringType _DisplayType = DisplayType;
			IntType _RecordCap = RecordCap;
			IntType _Interval = Interval;
			StringType _Period = Period;
			StringType _GroupType = GroupType;
			IntType _ExcludeInfinite = ExcludeInfinite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_ContentionInquirySP";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTNO", _ALTNO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayType", _DisplayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordCap", _RecordCap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Interval", _Interval, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupType", _GroupType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeInfinite", _ExcludeInfinite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
