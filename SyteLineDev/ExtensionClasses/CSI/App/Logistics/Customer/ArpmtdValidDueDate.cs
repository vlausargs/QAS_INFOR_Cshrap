//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdValidDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdValidDueDate : IArpmtdValidDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdValidDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DueDate,
		string Infobar) ArpmtdValidDueDateSp(string InvNum,
		DateTime? DueDate,
		string Infobar)
		{
			InvNumType _InvNum = InvNum;
			DateType _DueDate = DueDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdValidDueDateSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				Infobar = _Infobar;
				
				return (Severity, DueDate, Infobar);
			}
		}
	}
}
