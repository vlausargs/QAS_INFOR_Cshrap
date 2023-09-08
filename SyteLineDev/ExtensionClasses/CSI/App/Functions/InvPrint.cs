//PROJECT NAME: Data
//CLASS NAME: InvPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvPrint : IInvPrint
	{
		readonly IApplicationDB appDB;
		
		public InvPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TPrintInvNum,
			int? TPrintInvSeq,
			string Infobar) InvPrintSp(
			int? Progressive = 0,
			string Mode = "REPRINT",
			string TPrintInvNum = null,
			int? TPrintInvSeq = 0,
			string PrintItemCustomerItem = "IC",
			int? TransToDomCurr = 1,
			string InvCred = "I",
			int? PrintSerialNumbers = 0,
			int? PrintPlanItemMaterials = 0,
			string PrintConfigrationDetail = "N",
			int? PrintEuro = 0,
			int? PrintCustomerNotes = 0,
			int? PrintOrderNotes = 0,
			int? PrintOrderLineNotes = 0,
			int? PrintOrderBlanketLineNotes = 0,
			int? PrintProgressiveBillingNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintItemOverview = 0,
			int? PrintLineReleaseDescription = 0,
			int? PrintStandardOrderText = 0,
			int? PrintBillToNotes = 0,
			string Infobar = null,
			int? PrintDiscountAmt = 0,
			int? PrintLotNumbers = 0)
		{
			ListYesNoType _Progressive = Progressive;
			StringType _Mode = Mode;
			InvNumType _TPrintInvNum = TPrintInvNum;
			InvSeqType _TPrintInvSeq = TPrintInvSeq;
			StringType _PrintItemCustomerItem = PrintItemCustomerItem;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			StringType _InvCred = InvCred;
			ListYesNoType _PrintSerialNumbers = PrintSerialNumbers;
			ListYesNoType _PrintPlanItemMaterials = PrintPlanItemMaterials;
			StringType _PrintConfigrationDetail = PrintConfigrationDetail;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintOrderLineNotes = PrintOrderLineNotes;
			ListYesNoType _PrintOrderBlanketLineNotes = PrintOrderBlanketLineNotes;
			ListYesNoType _PrintProgressiveBillingNotes = PrintProgressiveBillingNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPrintSp";
				
				appDB.AddCommandParameter(cmd, "Progressive", _Progressive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPrintInvNum", _TPrintInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPrintInvSeq", _TPrintInvSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintItemCustomerItem", _PrintItemCustomerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerialNumbers", _PrintSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanItemMaterials", _PrintPlanItemMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintConfigrationDetail", _PrintConfigrationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderLineNotes", _PrintOrderLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderBlanketLineNotes", _PrintOrderBlanketLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProgressiveBillingNotes", _PrintProgressiveBillingNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TPrintInvNum = _TPrintInvNum;
				TPrintInvSeq = _TPrintInvSeq;
				Infobar = _Infobar;
				
				return (Severity, TPrintInvNum, TPrintInvSeq, Infobar);
			}
		}
	}
}
