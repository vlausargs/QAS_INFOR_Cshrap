//PROJECT NAME: Production
//CLASS NAME: PP_SaveJobProperties.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_SaveJobProperties : IPP_SaveJobProperties
	{
		readonly IApplicationDB appDB;
		
		
		public PP_SaveJobProperties(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PP_SaveJobPropertiesSp(string Job,
		int? suffix,
		int? Out,
		int? Up,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _suffix = suffix;
			PP_OutNumberType _Out = Out;
			PP_UpNumberType _Up = Up;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_SaveJobPropertiesSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suffix", _suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Out", _Out, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Up", _Up, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
