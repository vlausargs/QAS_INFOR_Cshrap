//PROJECT NAME: CSICodes
//CLASS NAME: PortalOrderStatusChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPortalOrderStatusChange
	{
		int PortalOrderStatusChangeSp(string CoNum,
		                              ref string Infobar);
	}
	
	public class PortalOrderStatusChange : IPortalOrderStatusChange
	{
		readonly IApplicationDB appDB;
		
		public PortalOrderStatusChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalOrderStatusChangeSp(string CoNum,
		                                     ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalOrderStatusChangeSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
