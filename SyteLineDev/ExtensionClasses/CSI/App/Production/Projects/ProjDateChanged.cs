//PROJECT NAME: CSIProjects
//CLASS NAME: ProjDateChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjDateChanged
	{
		int ProjDateChangedSp(string ProjNum,
		                      string CurrCode,
		                      DateTime? ProjDate,
		                      ref decimal? ExchRate,
		                      ref string Infobar);
	}
	
	public class ProjDateChanged : IProjDateChanged
	{
		readonly IApplicationDB appDB;
		
		public ProjDateChanged(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjDateChangedSp(string ProjNum,
		                             string CurrCode,
		                             DateTime? ProjDate,
		                             ref decimal? ExchRate,
		                             ref string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			CurrCodeType _CurrCode = CurrCode;
			DateType _ProjDate = ProjDate;
			ExchRateType _ExchRate = ExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjDateChangedSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjDate", _ProjDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
