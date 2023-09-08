//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvPrint : ISSSFSConInvPrint
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSConInvPrintSp(
			string TPrintInvNum,
			string MooreForm = "N",
			int? TransToDomCurr = 0,
			int? PrintEuro = 0,
			int? PrintBillToNotes = 0,
			int? PrintContractNotes = 0,
			int? PrintContLineNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintFixedContLines = 0,
			string Infobar = null,
			int? Summarize = 0)
		{
			InvNumType _TPrintInvNum = TPrintInvNum;
			StringType _MooreForm = MooreForm;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _PrintContractNotes = PrintContractNotes;
			ListYesNoType _PrintContLineNotes = PrintContLineNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintFixedContLines = PrintFixedContLines;
			Infobar _Infobar = Infobar;
			ListYesNoType _Summarize = Summarize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvPrintSp";
				
				appDB.AddCommandParameter(cmd, "TPrintInvNum", _TPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MooreForm", _MooreForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintContractNotes", _PrintContractNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintContLineNotes", _PrintContLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintFixedContLines", _PrintFixedContLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Summarize", _Summarize, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
