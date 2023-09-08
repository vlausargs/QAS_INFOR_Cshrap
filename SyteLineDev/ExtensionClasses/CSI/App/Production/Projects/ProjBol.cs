//PROJECT NAME: CSIProjects
//CLASS NAME: ProjBol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjBol
	{
		int ProjBolSp(string ProjNum,
		              ref string BolNum,
		              ref string Infobar);
	}
	
	public class ProjBol : IProjBol
	{
		readonly IApplicationDB appDB;
		
		public ProjBol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjBolSp(string ProjNum,
		                     ref string BolNum,
		                     ref string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			BolNumType _BolNum = BolNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjBolSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BolNum", _BolNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BolNum = _BolNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
