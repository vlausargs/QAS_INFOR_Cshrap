//PROJECT NAME: Data
//CLASS NAME: PSReleaseQtyChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PSReleaseQtyChange : IPSReleaseQtyChange
	{
		readonly IApplicationDB appDB;
		
		public PSReleaseQtyChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PSReleaseQtyChangeSp(
			string RJob,
			int? RSuffix,
			string Infobar)
		{
			JobType _RJob = RJob;
			SuffixType _RSuffix = RSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSReleaseQtyChangeSp";
				
				appDB.AddCommandParameter(cmd, "RJob", _RJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RSuffix", _RSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
