//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_RemoveSubContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IAU_RemoveSubContainer
	{
		int AU_RemoveSubContainerSp(string ContainerNum,
		                            ref string Infobar);
	}
	
	public class AU_RemoveSubContainer : IAU_RemoveSubContainer
	{
		readonly IApplicationDB appDB;
		
		public AU_RemoveSubContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int AU_RemoveSubContainerSp(string ContainerNum,
		                                   ref string Infobar)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_RemoveSubContainerSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
