//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjParmDevPerc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetProjParmDevPerc
	{
		int GetProjParmDevPercSp(ref decimal? pSchVarLowDev,
		                         ref decimal? pSchVarUpDev,
		                         ref byte? pSchVarPri,
		                         ref decimal? pCostCodeVarLowDev,
		                         ref decimal? pCostCodeVarUpDev,
		                         ref byte? pCostCodeVarPri);
	}
	
	public class GetProjParmDevPerc : IGetProjParmDevPerc
	{
		readonly IApplicationDB appDB;
		
		public GetProjParmDevPerc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetProjParmDevPercSp(ref decimal? pSchVarLowDev,
		                                ref decimal? pSchVarUpDev,
		                                ref byte? pSchVarPri,
		                                ref decimal? pCostCodeVarLowDev,
		                                ref decimal? pCostCodeVarUpDev,
		                                ref byte? pCostCodeVarPri)
		{
			TolerancePercentType _pSchVarLowDev = pSchVarLowDev;
			TolerancePercentType _pSchVarUpDev = pSchVarUpDev;
			ProjVariancePriorityType _pSchVarPri = pSchVarPri;
			TolerancePercentType _pCostCodeVarLowDev = pCostCodeVarLowDev;
			TolerancePercentType _pCostCodeVarUpDev = pCostCodeVarUpDev;
			ProjVariancePriorityType _pCostCodeVarPri = pCostCodeVarPri;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProjParmDevPercSp";
				
				appDB.AddCommandParameter(cmd, "pSchVarLowDev", _pSchVarLowDev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSchVarUpDev", _pSchVarUpDev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSchVarPri", _pSchVarPri, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCostCodeVarLowDev", _pCostCodeVarLowDev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCostCodeVarUpDev", _pCostCodeVarUpDev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCostCodeVarPri", _pCostCodeVarPri, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pSchVarLowDev = _pSchVarLowDev;
				pSchVarUpDev = _pSchVarUpDev;
				pSchVarPri = _pSchVarPri;
				pCostCodeVarLowDev = _pCostCodeVarLowDev;
				pCostCodeVarUpDev = _pCostCodeVarUpDev;
				pCostCodeVarPri = _pCostCodeVarPri;
				
				return Severity;
			}
		}
	}
}
