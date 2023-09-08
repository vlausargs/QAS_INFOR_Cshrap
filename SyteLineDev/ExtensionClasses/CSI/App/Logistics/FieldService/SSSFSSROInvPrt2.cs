//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroInvPrt2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroInvPrt2 : ISSSFSSroInvPrt2
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroInvPrt2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TSubTotal,
			string Infobar) SSSFSSroInvPrt2Sp(
			string Mode = "PROCESS",
			string TPrintInvNum = null,
			int? TransToDomCurr = 0,
			int? TEuroExists = 0,
			int? PrintSROLineNotes = 0,
			int? PrintSROOperNotes = 0,
			int? PrintTransNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintSerials = 0,
			int? PrintProjMatl = 0,
			int? PrintProjLabor = 0,
			int? PrintProjMisc = 0,
			int? SummarizeTrans = 0,
			string OrderBy = null,
			decimal? TSubTotal = null,
			string Infobar = null)
		{
			StringType _Mode = Mode;
			InvNumType _TPrintInvNum = TPrintInvNum;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			ListYesNoType _TEuroExists = TEuroExists;
			ListYesNoType _PrintSROLineNotes = PrintSROLineNotes;
			ListYesNoType _PrintSROOperNotes = PrintSROOperNotes;
			ListYesNoType _PrintTransNotes = PrintTransNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintSerials = PrintSerials;
			ListYesNoType _PrintProjMatl = PrintProjMatl;
			ListYesNoType _PrintProjLabor = PrintProjLabor;
			ListYesNoType _PrintProjMisc = PrintProjMisc;
			ListYesNoType _SummarizeTrans = SummarizeTrans;
			StringType _OrderBy = OrderBy;
			AmountType _TSubTotal = TSubTotal;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroInvPrt2Sp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPrintInvNum", _TPrintInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroExists", _TEuroExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROLineNotes", _PrintSROLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROOperNotes", _PrintSROOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTransNotes", _PrintTransNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerials", _PrintSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjMatl", _PrintProjMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjLabor", _PrintProjLabor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjMisc", _PrintProjMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummarizeTrans", _SummarizeTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSubTotal", _TSubTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSubTotal = _TSubTotal;
				Infobar = _Infobar;
				
				return (Severity, TSubTotal, Infobar);
			}
		}
	}
}
