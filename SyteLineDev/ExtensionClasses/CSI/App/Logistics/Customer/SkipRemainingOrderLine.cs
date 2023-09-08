//PROJECT NAME: Logistics
//CLASS NAME: SkipRemainingOrderLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SkipRemainingOrderLine : ISkipRemainingOrderLine
	{
		readonly IApplicationDB appDB;
		
		
		public SkipRemainingOrderLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SkipRemainingOrderLineSp(Guid? ProcessId,
		string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SkipRemainingOrderLineSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
