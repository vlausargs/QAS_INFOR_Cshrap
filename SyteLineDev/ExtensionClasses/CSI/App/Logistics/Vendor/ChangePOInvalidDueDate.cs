//PROJECT NAME: Logistics
//CLASS NAME: ChangePOInvalidDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ChangePOInvalidDueDate : IChangePOInvalidDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public ChangePOInvalidDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ChangePOInvalidDueDateSp(int? Selected,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string PoVendNum,
		DateTime? OldDueDate,
		DateTime? NewDueDate,
		string Infobar)
		{
			ListYesNoType _Selected = Selected;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			VendNumType _PoVendNum = PoVendNum;
			DateType _OldDueDate = OldDueDate;
			DateType _NewDueDate = NewDueDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangePOInvalidDueDateSp";
				
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVendNum", _PoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldDueDate", _OldDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewDueDate", _NewDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
