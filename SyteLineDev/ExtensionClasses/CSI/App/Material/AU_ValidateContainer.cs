//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_ValidateContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IAU_ValidateContainer
	{
		int AU_ValidateContainerSp(string Whse,
		                           string RefType,
		                           string ContainerNum,
		                           ref string Infobar);
	}
	
	public class AU_ValidateContainer : IAU_ValidateContainer
	{
		readonly IApplicationDB appDB;
		
		public AU_ValidateContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int AU_ValidateContainerSp(string Whse,
		                                  string RefType,
		                                  string ContainerNum,
		                                  ref string Infobar)
		{
			WhseType _Whse = Whse;
			RefType _RefType = RefType;
			ContainerNumType _ContainerNum = ContainerNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_ValidateContainerSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
