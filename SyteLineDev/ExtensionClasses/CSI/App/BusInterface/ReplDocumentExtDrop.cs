//PROJECT NAME: CSIBusInterface
//CLASS NAME: ReplDocumentExtDrop.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface IReplDocumentExtDrop
	{
		int ReplDocumentExtDropSp(string InfoBar);
	}
	
	public class ReplDocumentExtDrop : IReplDocumentExtDrop
	{
		readonly IApplicationDB appDB;
		
		public ReplDocumentExtDrop(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ReplDocumentExtDropSp(string InfoBar)
		{
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReplDocumentExtDropSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
