//PROJECT NAME: Logistics
//CLASS NAME: InvoiceBuilderDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvoiceBuilderDelete : IInvoiceBuilderDelete
	{
		readonly IApplicationDB appDB;
		
		
		public InvoiceBuilderDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InvoiceBuilderDeleteSp(Guid? PProcessID,
		string PCustNum = null)
		{
			RowPointerType _PProcessID = PProcessID;
			CustNumType _PCustNum = PCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoiceBuilderDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
