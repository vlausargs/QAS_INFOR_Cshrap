//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDrpProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSDrpProcess
	{
		int SSSFSDrpProcessSp(ref string Infobar);
	}
	
	public class SSSFSDrpProcess : ISSSFSDrpProcess
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDrpProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSDrpProcessSp(ref string Infobar)
		{
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDrpProcessSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
