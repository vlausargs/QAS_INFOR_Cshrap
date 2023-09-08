//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDrpClear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSDrpClear
	{
		int SSSFSDrpClearSp(ref string Infobar);
	}
	
	public class SSSFSDrpClear : ISSSFSDrpClear
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDrpClear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSDrpClearSp(ref string Infobar)
		{
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDrpClearSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
