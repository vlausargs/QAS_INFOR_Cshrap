//PROJECT NAME: CSIProjects
//CLASS NAME: ProjBolPack.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjBolPack
	{
		int ProjBolPackSp(string PProjNum,
		                  int? PPackSlip,
		                  ref string PBolNum,
		                  ref string Infobar);
	}
	
	public class ProjBolPack : IProjBolPack
	{
		readonly IApplicationDB appDB;
		
		public ProjBolPack(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjBolPackSp(string PProjNum,
		                         int? PPackSlip,
		                         ref string PBolNum,
		                         ref string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			PackNumType _PPackSlip = PPackSlip;
			BolNumType _PBolNum = PBolNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjBolPackSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPackSlip", _PPackSlip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBolNum", _PBolNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PBolNum = _PBolNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
