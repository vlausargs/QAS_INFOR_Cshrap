//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IContainerAdd
	{
		int ContainerAddSp(ref string ContainerNum,
		                   string Whse,
		                   string Loc,
		                   ref string Infobar);
	}
	
	public class ContainerAdd : IContainerAdd
	{
		readonly IApplicationDB appDB;
		
		public ContainerAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ContainerAddSp(ref string ContainerNum,
		                          string Whse,
		                          string Loc,
		                          ref string Infobar)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ContainerAddSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ContainerNum = _ContainerNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
