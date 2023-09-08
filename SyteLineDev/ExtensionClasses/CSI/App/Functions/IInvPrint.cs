//PROJECT NAME: Data
//CLASS NAME: IInvPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvPrint
	{
		(int? ReturnCode,
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
			int? PrintLotNumbers = 0);
	}
}

