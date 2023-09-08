//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubLoadOldInvoices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubLoadOldInvoices : ISSSFSConInvSubLoadOldInvoices
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubLoadOldInvoices(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubLoadOldInvoicesSp(
			Guid? SessionId,
			string Contract,
			int? ContLine)
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubLoadOldInvoicesSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
