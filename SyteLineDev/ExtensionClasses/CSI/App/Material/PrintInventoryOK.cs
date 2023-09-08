//PROJECT NAME: Material
//CLASS NAME: PrintInventoryOK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PrintInventoryOK : IPrintInventoryOK
	{
		readonly IApplicationDB appDB;
		
		public PrintInventoryOK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PrintInventoryOKSp(
			string Whse,
			int? bSheetsOrTags,
			int? bPrintBlankTagSheet,
			string Infobar)
		{
			WhseType _Whse = Whse;
			ListYesNoType _bSheetsOrTags = bSheetsOrTags;
			ListYesNoType _bPrintBlankTagSheet = bPrintBlankTagSheet;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInventoryOKSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bSheetsOrTags", _bSheetsOrTags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBlankTagSheet", _bPrintBlankTagSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
