//PROJECT NAME: Material
//CLASS NAME: RcptsLeaveDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class RcptsLeaveDueDate : IRcptsLeaveDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public RcptsLeaveDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RcptsLeaveDueDateSp(DateTime? DueDate,
		string Item,
		Guid? NewRowPointer,
		string Infobar)
		{
			DateType _DueDate = DueDate;
			ItemType _Item = Item;
			RowPointerType _NewRowPointer = NewRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RcptsLeaveDueDateSp";
				
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRowPointer", _NewRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
