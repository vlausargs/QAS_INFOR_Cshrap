//PROJECT NAME: Production
//CLASS NAME: PmfPnJobGetLineStatsUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnJobGetLineStatsUi : IPmfPnJobGetLineStatsUi
	{
		readonly IApplicationDB appDB;
		
		public PmfPnJobGetLineStatsUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			decimal? MatlPctComplete,
			decimal? ProdPctComplete) PmfPnJobGetLineStatsUiSp(
			string InfoBar = null,
			Guid? PnRp = null,
			Guid? JobRp = null,
			decimal? MatlPctComplete = null,
			decimal? ProdPctComplete = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			RowPointerType _JobRp = JobRp;
			QtyUnitType _MatlPctComplete = MatlPctComplete;
			QtyUnitType _ProdPctComplete = ProdPctComplete;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnJobGetLineStatsUiSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlPctComplete", _MatlPctComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProdPctComplete", _ProdPctComplete, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				MatlPctComplete = _MatlPctComplete;
				ProdPctComplete = _ProdPctComplete;
				
				return (Severity, InfoBar, MatlPctComplete, ProdPctComplete);
			}
		}
	}
}
