//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispRwrkPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispRwrkPre : ISSSRMXDispRwrkPre
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispRwrkPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSRMXDispRwrkPreSp(
			Guid? DispRowPointer,
			string Infobar)
		{
			RowPointer _DispRowPointer = DispRowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDispRwrkPreSp";
				
				appDB.AddCommandParameter(cmd, "DispRowPointer", _DispRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
