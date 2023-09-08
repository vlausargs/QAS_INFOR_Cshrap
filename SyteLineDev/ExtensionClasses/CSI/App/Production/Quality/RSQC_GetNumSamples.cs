//PROJECT NAME: Production
//CLASS NAME: RSQC_GetNumSamples.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetNumSamples : IRSQC_GetNumSamples
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetNumSamples(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_samples) RSQC_GetNumSamplesSp(int? rcvr_num,
		int? o_samples)
		{
			IntType _rcvr_num = rcvr_num;
			IntType _o_samples = o_samples;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetNumSamplesSp";
				
				appDB.AddCommandParameter(cmd, "rcvr_num", _rcvr_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_samples", _o_samples, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_samples = _o_samples;
				
				return (Severity, o_samples);
			}
		}
	}
}
