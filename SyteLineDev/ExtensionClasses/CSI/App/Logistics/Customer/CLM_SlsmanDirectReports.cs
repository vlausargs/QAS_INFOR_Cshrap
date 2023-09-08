//PROJECT NAME: Logistics
//CLASS NAME: CLM_SlsmanDirectReports.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_SlsmanDirectReports : ICLM_SlsmanDirectReports
	{
		readonly IApplicationDB appDB;
		
		
		public CLM_SlsmanDirectReports(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SlsManList) CLM_SlsmanDirectReportsSp(string SlsmanID,
		int? IncludeDirectReports,
		string SlsManList)
		{
			SlsmanType _SlsmanID = SlsmanID;
			IntType _IncludeDirectReports = IncludeDirectReports;
			LongListType _SlsManList = SlsManList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_SlsmanDirectReportsSp";
				
				appDB.AddCommandParameter(cmd, "SlsmanID", _SlsmanID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeDirectReports", _IncludeDirectReports, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SlsManList", _SlsManList, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SlsManList = _SlsManList;
				
				return (Severity, SlsManList);
			}
		}
	}
}
