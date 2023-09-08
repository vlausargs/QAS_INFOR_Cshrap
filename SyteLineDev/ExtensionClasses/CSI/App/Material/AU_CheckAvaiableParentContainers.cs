//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_CheckAvaiableParentContainers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IAU_CheckAvaiableParentContainers
	{
		int AU_CheckAvaiableParentContainersSp(string ContainerNum,
		                                       string ParentContainerNum,
		                                       string Whse,
		                                       string Loc,
		                                       ref string Infobar);
	}
	
	public class AU_CheckAvaiableParentContainers : IAU_CheckAvaiableParentContainers
	{
		readonly IApplicationDB appDB;
		
		public AU_CheckAvaiableParentContainers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int AU_CheckAvaiableParentContainersSp(string ContainerNum,
		                                              string ParentContainerNum,
		                                              string Whse,
		                                              string Loc,
		                                              ref string Infobar)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			ContainerNumType _ParentContainerNum = ParentContainerNum;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_CheckAvaiableParentContainersSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentContainerNum", _ParentContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
