//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSApsSyncImmediate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSApsSyncImmediate
	{
		int SSSFSApsSyncImmediateSp(ref string Infobar,
		                            int? DropDeferred);
	}
	
	public class SSSFSApsSyncImmediate : ISSSFSApsSyncImmediate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSApsSyncImmediate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSApsSyncImmediateSp(ref string Infobar,
		                                   int? DropDeferred)
		{
			InfobarType _Infobar = Infobar;
			IntType _DropDeferred = DropDeferred;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSApsSyncImmediateSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DropDeferred", _DropDeferred, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
