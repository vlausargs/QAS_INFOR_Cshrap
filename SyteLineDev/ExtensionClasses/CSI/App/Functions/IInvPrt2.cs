//PROJECT NAME: Data
//CLASS NAME: IInvPrt2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvPrt2
	{
		(int? ReturnCode,
			decimal? TSubPrice,
			decimal? TDiscCiPrice,
			string TPrintInvNum,
			decimal? TEuroTotal,
			string Infobar,
			int? PrintEuro) InvPrt2Sp(
			int? Progressive = 0,
			string Mode = "REPRINT",
			decimal? TSubPrice = 0,
			decimal? TDiscCiPrice = 0,
			string TPrintInvNum = "0",
			decimal? TEuroTotal = 0,
			int? TransToDomCurr = 1,
			string PrintItemCustomerItem = "IC",
			int? PrintSerialNumbers = 0,
			string InvCred = "I",
			int? PrintPlanItemMaterial = 0,
			string PrintConfigurationDetail = "N",
			int? TEuroExists = 0,
			int? PrintOrderLineNotes = 0,
			int? PrintOrderBlanketLineNotes = 0,
			int? PrintProgressiveBillingNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintItemOverview = 0,
			int? PrintLineReleaseDescription = 0,
			string Infobar = null,
			int? PrintEuro = 0,
			int? PrintLotNumbers = 0);
	}
}

