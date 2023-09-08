//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IContainerDelete
	{
		int ContainerDeleteSp(string PContainerNum,
		                      ref string Infobar);
	}
	
	public class ContainerDelete : IContainerDelete
	{
		readonly IApplicationDB appDB;
		
		public ContainerDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ContainerDeleteSp(string PContainerNum,
		                             ref string Infobar)
		{
			ContainerNumType _PContainerNum = PContainerNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ContainerDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PContainerNum", _PContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
