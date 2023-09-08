//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckContainerRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ICheckContainerRef
	{
		int CheckContainerRefSp(string ContainerNum,
		                        string CoNum,
		                        ref string Infobar);
	}
	
	public class CheckContainerRef : ICheckContainerRef
	{
		readonly IApplicationDB appDB;
		
		public CheckContainerRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckContainerRefSp(string ContainerNum,
		                               string CoNum,
		                               ref string Infobar)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			CoNumType _CoNum = CoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckContainerRefSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
