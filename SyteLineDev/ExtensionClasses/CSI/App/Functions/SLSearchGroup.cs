//PROJECT NAME: Data
//CLASS NAME: SLSearchGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SLSearchGroup : ISLSearchGroup
	{
		readonly IApplicationDB appDB;
		
		public SLSearchGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ResultSet,
			string InfobarType) SLSearchGroupSp(
			string GetorSearchList,
			string emailid,
			string ResultSet,
			string InfobarType)
		{
			StringType _GetorSearchList = GetorSearchList;
			InfobarType _emailid = emailid;
			InfobarType _ResultSet = ResultSet;
			InfobarType _InfobarType = InfobarType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SLSearchGroupSp";
				
				appDB.AddCommandParameter(cmd, "GetorSearchList", _GetorSearchList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "emailid", _emailid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResultSet", _ResultSet, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfobarType", _InfobarType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ResultSet = _ResultSet;
				InfobarType = _InfobarType;
				
				return (Severity, ResultSet, InfobarType);
			}
		}
	}
}
