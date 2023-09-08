//PROJECT NAME: Logistics
//CLASS NAME: InvoiceBuilderSaveDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvoiceBuilderSaveDist : IInvoiceBuilderSaveDist
	{
		readonly IApplicationDB appDB;
		
		
		public InvoiceBuilderSaveDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InvoiceBuilderSaveDistSp(Guid? PRowPointer,
		Guid? PProcessId = null,
		int? PSelected = null,
		string PCustNum = null,
		int? PClearSel = 0)
		{
			RowPointerType _PRowPointer = PRowPointer;
			RowPointerType _PProcessId = PProcessId;
			ListYesNoType _PSelected = PSelected;
			CustNumType _PCustNum = PCustNum;
			ListYesNoType _PClearSel = PClearSel;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoiceBuilderSaveDistSp";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSelected", _PSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PClearSel", _PClearSel, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
