//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_NumSamples.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_NumSamples : IRpt_RSQC_NumSamples
	{
		readonly IApplicationDB appDB;
		
		public Rpt_RSQC_NumSamples(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_RSQC_NumSamplesSp(
			int? numsamples = null)
		{
			IntType _numsamples = numsamples;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_NumSamplesSp";
				
				appDB.AddCommandParameter(cmd, "numsamples", _numsamples, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
