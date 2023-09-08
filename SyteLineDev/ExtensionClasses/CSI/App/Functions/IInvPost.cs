//PROJECT NAME: Data
//CLASS NAME: IInvPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvPost
	{
		(int? ReturnCode,
			string TInvNum,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			int? InvoiceCount,
			int? EDINoPaperInvoiceCount) InvPostSp(
			string InvType = "R",
			string InvCred = "I",
			DateTime? InvDate = null,
			string StartCustomer = null,
			string EndCustomer = null,
			string StartOrderNum = null,
			string EndOrderNum = null,
			int? StartLine = null,
			int? EndLine = null,
			int? StartRelease = null,
			int? EndRelease = null,
			DateTime? StartLastShipDate = null,
			DateTime? EndLastShipDate = null,
			decimal? StartShipmentId = null,
			decimal? EndShipmentId = null,
			string pMooreForms = "N",
			int? pNonDraftCust = 0,
			int? PackNum = 0,
			int? CheckShipItemActiveFlag = 0,
			string TInvNum = "0",
			string StartInvNum = null,
			string EndInvNum = null,
			string Infobar = null,
			int? BatchId = null,
			Guid? ProcessId = null,
			int? InvoiceCount = 0,
			int? EDINoPaperInvoiceCount = 0,
			int? StartPackNum = null,
			int? EndPackNum = null,
			int? CreateFromPackSlip = 0,
			int? CreateFromShipment = 0,
			string CalledFrom = null,
			Guid? InvoicBuilderProcessID = null);
	}
}

