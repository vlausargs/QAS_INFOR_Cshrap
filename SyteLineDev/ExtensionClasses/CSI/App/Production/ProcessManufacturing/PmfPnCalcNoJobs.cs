//PROJECT NAME: Production
//CLASS NAME: PmfPnCalcNoJobs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnCalcNoJobs : IPmfPnCalcNoJobs
	{
		readonly IApplicationDB appDB;
		
		public PmfPnCalcNoJobs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			decimal? TotalQty,
			int? NoJobs,
			decimal? FirstJobSize,
			decimal? LastJobSize) PmfPnCalcNoJobsSp(
			string InfoBar = null,
			decimal? TotalQty = null,
			decimal? MinSize = null,
			decimal? MaxSize = null,
			decimal? SizeMultiple = 0,
			int? NoJobs = null,
			decimal? FirstJobSize = null,
			decimal? LastJobSize = null)
		{
			InfobarType _InfoBar = InfoBar;
			ProcessMfgQuantityType _TotalQty = TotalQty;
			ProcessMfgQuantityType _MinSize = MinSize;
			ProcessMfgQuantityType _MaxSize = MaxSize;
			ProcessMfgQuantityType _SizeMultiple = SizeMultiple;
			IntType _NoJobs = NoJobs;
			ProcessMfgQuantityType _FirstJobSize = FirstJobSize;
			ProcessMfgQuantityType _LastJobSize = LastJobSize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnCalcNoJobsSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalQty", _TotalQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MinSize", _MinSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxSize", _MaxSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SizeMultiple", _SizeMultiple, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoJobs", _NoJobs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FirstJobSize", _FirstJobSize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastJobSize", _LastJobSize, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				TotalQty = _TotalQty;
				NoJobs = _NoJobs;
				FirstJobSize = _FirstJobSize;
				LastJobSize = _LastJobSize;
				
				return (Severity, InfoBar, TotalQty, NoJobs, FirstJobSize, LastJobSize);
			}
		}
	}
}
