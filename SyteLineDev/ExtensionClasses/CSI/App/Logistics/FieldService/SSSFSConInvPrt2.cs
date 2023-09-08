//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvPrt2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvPrt2 : ISSSFSConInvPrt2
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvPrt2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSConInvPrt2Sp(
			string TPrintInvNum,
			int? TransToDomCurr,
			string MooreForm,
			int? PrintContLineNotes,
			int? PrintInternalNotes,
			int? PrintExternalNotes,
			int? PrintFixedContLines,
			string Infobar,
			int? Summarize = 0)
		{
			InvNumType _TPrintInvNum = TPrintInvNum;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			StringType _MooreForm = MooreForm;
			ListYesNoType _PrintContLineNotes = PrintContLineNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintFixedContLines = PrintFixedContLines;
			Infobar _Infobar = Infobar;
			ListYesNoType _Summarize = Summarize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvPrt2Sp";
				
				appDB.AddCommandParameter(cmd, "TPrintInvNum", _TPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MooreForm", _MooreForm, ParameterDirection.Input);
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
