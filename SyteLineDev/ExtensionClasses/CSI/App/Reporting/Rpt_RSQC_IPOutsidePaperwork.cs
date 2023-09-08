//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPOutsidePaperwork.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPOutsidePaperwork : IRpt_RSQC_IPOutsidePaperwork
	{
		readonly IApplicationDB appDB;
		
		public Rpt_RSQC_IPOutsidePaperwork(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_RSQC_IPOutsidePaperworkSp(
			string begjob = null,
			int? begsuff = null,
			int? begoper = null)
		{
			JobType _begjob = begjob;
			SuffixType _begsuff = begsuff;
			OperNumType _begoper = begoper;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_IPOutsidePaperworkSp";
				
				appDB.AddCommandParameter(cmd, "begjob", _begjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begsuff", _begsuff, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begoper", _begoper, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
