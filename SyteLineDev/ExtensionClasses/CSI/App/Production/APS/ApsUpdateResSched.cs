//PROJECT NAME: Production
//CLASS NAME: ApsUpdateResSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsUpdateResSched : IApsUpdateResSched
	{
		readonly IApplicationDB appDB;
		
		
		public ApsUpdateResSched(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsUpdateResSchedSp(string EditCode,
		string ResourceID,
		string GroupID,
		DateTime? StartDate,
		string StartCode,
		DateTime? EndDate,
		string EndCode,
		int? Jobtag,
		int? Seqnum,
		string StatusCode,
		Guid? RowPointer)
		{
			UserCodeType _EditCode = EditCode;
			ApsResourceType _ResourceID = ResourceID;
			ApsResgroupType _GroupID = GroupID;
			DateType _StartDate = StartDate;
			UserCodeType _StartCode = StartCode;
			DateType _EndDate = EndDate;
			UserCodeType _EndCode = EndCode;
			ApsIntType _Jobtag = Jobtag;
			ApsIntType _Seqnum = Seqnum;
			UserCodeType _StatusCode = StatusCode;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsUpdateResSchedSp";
				
				appDB.AddCommandParameter(cmd, "EditCode", _EditCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceID", _ResourceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupID", _GroupID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCode", _StartCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCode", _EndCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Jobtag", _Jobtag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seqnum", _Seqnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCode", _StatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
