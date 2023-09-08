//PROJECT NAME: CSIProjects
//CLASS NAME: ProjInitpbol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjInitpbol
	{
		int ProjInitpbolSp(string PProjNum,
		                   string PBolNum,
		                   int? PPackNum,
		                   byte? PCopyFromPackSlip);
	}
	
	public class ProjInitpbol : IProjInitpbol
	{
		readonly IApplicationDB appDB;
		
		public ProjInitpbol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjInitpbolSp(string PProjNum,
		                          string PBolNum,
		                          int? PPackNum,
		                          byte? PCopyFromPackSlip)
		{
			ProjNumType _PProjNum = PProjNum;
			BolNumType _PBolNum = PBolNum;
			PackNumType _PPackNum = PPackNum;
			FlagNyType _PCopyFromPackSlip = PCopyFromPackSlip;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjInitpbolSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBolNum", _PBolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPackNum", _PPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCopyFromPackSlip", _PCopyFromPackSlip, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
