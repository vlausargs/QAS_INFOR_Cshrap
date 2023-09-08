//PROJECT NAME: Admin
//CLASS NAME: SLPreciseSearchPreferenceLists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ISLPreciseSearchPreferenceLists
	{
		(int? ReturnCode, string InfobarType,
		string xmlResult) SLPreciseSearchPreferenceListsSp(string emailBody,
		string emailid,
		string InfobarType,
		string xmlResult,
		string formDBName);
	}
	
	public class SLPreciseSearchPreferenceLists : ISLPreciseSearchPreferenceLists
	{
		IApplicationDB appDB;
		
		public SLPreciseSearchPreferenceLists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfobarType,
		string xmlResult) SLPreciseSearchPreferenceListsSp(string emailBody,
		string emailid,
		string InfobarType,
		string xmlResult,
		string formDBName)
		{
			StringType _emailBody = emailBody;
			StringType _emailid = emailid;
			InfobarType _InfobarType = InfobarType;
			StringType _xmlResult = xmlResult;
			StringType _formDBName = formDBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SLPreciseSearchPreferenceListsSp";
				
				appDB.AddCommandParameter(cmd, "emailBody", _emailBody, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "emailid", _emailid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfobarType", _InfobarType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "xmlResult", _xmlResult, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "formDBName", _formDBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfobarType = _InfobarType;
				xmlResult = _xmlResult;
				
				return (Severity, InfobarType, xmlResult);
			}
		}
	}
}
