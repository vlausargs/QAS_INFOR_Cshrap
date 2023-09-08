//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSIncEscalUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncEscalUtil
	{
		int SSSFSIncEscalUtilSp(ref string Infobar);
	}
	
	public class SSSFSIncEscalUtil : ISSSFSIncEscalUtil
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncEscalUtil(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSIncEscalUtilSp(ref string Infobar)
		{
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncEscalUtilSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
