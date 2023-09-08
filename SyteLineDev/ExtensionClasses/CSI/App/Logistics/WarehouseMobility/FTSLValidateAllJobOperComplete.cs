//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateAllJobOperComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateAllJobOperComplete
	{
		int FTSLValidateAllJobOperCompleteSp(string JobNum,
		                                     short? Suffix,
		                                     ref string Infobar);
	}
	
	public class FTSLValidateAllJobOperComplete : IFTSLValidateAllJobOperComplete
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateAllJobOperComplete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateAllJobOperCompleteSp(string JobNum,
		                                            short? Suffix,
		                                            ref string Infobar)
		{
			JobType _JobNum = JobNum;
			SuffixType _Suffix = Suffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateAllJobOperCompleteSp";
				
				appDB.AddCommandParameter(cmd, "JobNum", _JobNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
