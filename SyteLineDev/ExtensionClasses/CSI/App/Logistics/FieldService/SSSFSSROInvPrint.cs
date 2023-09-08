//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInvPrint : ISSSFSSROInvPrint
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSROInvPrintSp(
			string Mode = "PROCESS",
			string TPrintInvNum = null,
			string MooreForm = "N",
			int? TransToDomCurr = null,
			int? PrintEuro = 0,
			int? PrintBillToNotes = 0,
			int? PrintSRONotes = 0,
			int? PrintSROLineNotes = 0,
			int? PrintSROOperNotes = 0,
			int? PrintTransNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintSerials = 0,
			int? PrintMatl = 0,
			int? PrintLabor = 0,
			int? PrintMisc = 0,
			int? SummarizeTrans = 0,
			string BillCustCons = "U",
			string OrderBy = null,
			string Infobar = null)
		{
			StringType _Mode = Mode;
			InvNumType _TPrintInvNum = TPrintInvNum;
			StringType _MooreForm = MooreForm;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _PrintSRONotes = PrintSRONotes;
			ListYesNoType _PrintSROLineNotes = PrintSROLineNotes;
			ListYesNoType _PrintSROOperNotes = PrintSROOperNotes;
			ListYesNoType _PrintTransNotes = PrintTransNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintSerials = PrintSerials;
			ListYesNoType _PrintMatl = PrintMatl;
			ListYesNoType _PrintLabor = PrintLabor;
			ListYesNoType _PrintMisc = PrintMisc;
			ListYesNoType _SummarizeTrans = SummarizeTrans;
			StringType _BillCustCons = BillCustCons;
			StringType _OrderBy = OrderBy;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvPrintSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPrintInvNum", _TPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MooreForm", _MooreForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSRONotes", _PrintSRONotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROLineNotes", _PrintSROLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROOperNotes", _PrintSROOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTransNotes", _PrintTransNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerials", _PrintSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintMatl", _PrintMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLabor", _PrintLabor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintMisc", _PrintMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummarizeTrans", _SummarizeTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCustCons", _BillCustCons, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
