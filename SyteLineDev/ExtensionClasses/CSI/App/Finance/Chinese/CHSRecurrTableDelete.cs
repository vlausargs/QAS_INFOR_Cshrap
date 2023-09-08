//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSRecurrTableDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSRecurrTableDelete
	{
		int CHSRecurrTableDeleteSp(string UserName,
		                           ref string Infobar);
	}
	
	public class CHSRecurrTableDelete : ICHSRecurrTableDelete
	{
		readonly IApplicationDB appDB;
		
		public CHSRecurrTableDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CHSRecurrTableDeleteSp(string UserName,
		                                  ref string Infobar)
		{
			UsernameType _UserName = UserName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRecurrTableDeleteSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
