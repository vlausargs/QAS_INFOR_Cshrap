//PROJECT NAME: Employee
//CLASS NAME: PrtrxClearSnapshots.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPrtrxClearSnapshots
	{
		(int? ReturnCode, string Infobar) PrtrxClearSnapshotsSp(Guid? PSessionID = null,
		string Infobar = null);
	}
	
	public class PrtrxClearSnapshots : IPrtrxClearSnapshots
	{
		readonly IApplicationDB appDB;
		
		public PrtrxClearSnapshots(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PrtrxClearSnapshotsSp(Guid? PSessionID = null,
		string Infobar = null)
		{
			RowPointerType _PSessionID = PSessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtrxClearSnapshotsSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
