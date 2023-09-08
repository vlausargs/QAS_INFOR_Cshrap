//PROJECT NAME: Production
//CLASS NAME: PmfPnSizeByMatlAvail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnSizeByMatlAvail
	{
		(int? ReturnCode, string InfoBar) PmfPnSizeByMatlAvailSp(string InfoBar,
		                                                         string job,
		                                                         short? suffix);
	}
	
	public class PmfPnSizeByMatlAvail : IPmfPnSizeByMatlAvail
	{
		readonly IApplicationDB appDB;
		
		public PmfPnSizeByMatlAvail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnSizeByMatlAvailSp(string InfoBar,
		                                                                string job,
		                                                                short? suffix)
		{
			InfobarType _InfoBar = InfoBar;
			JobType _job = job;
			SuffixType _suffix = suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnSizeByMatlAvailSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suffix", _suffix, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
