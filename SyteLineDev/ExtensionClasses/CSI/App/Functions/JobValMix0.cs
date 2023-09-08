//PROJECT NAME: Data
//CLASS NAME: JobValMix0.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobValMix0 : IJobValMix0
	{
		readonly IApplicationDB appDB;
		
		public JobValMix0(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobValMix0Sp(
			string PProdMix,
			string Infobar)
		{
			ProdMixType _PProdMix = PProdMix;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobValMix0Sp";
				
				appDB.AddCommandParameter(cmd, "PProdMix", _PProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
