//PROJECT NAME: RFQ
//CLASS NAME: SSSRfqGenSetSelected.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRfqGenSetSelected : ISSSRfqGenSetSelected
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRfqGenSetSelected(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSRfqGenSetSelectedSp(Guid? RowPointer,
		int? Selected,
		string Infobar)
		{
			RowPointer _RowPointer = RowPointer;
			ListYesNoType _Selected = Selected;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRfqGenSetSelectedSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
