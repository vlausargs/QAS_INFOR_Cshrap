//PROJECT NAME: Data
//CLASS NAME: IInvPostP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvPostP
	{
		(int? ReturnCode,
			string TInvNum,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			int? InvoiceCount,
			int? EDINoPaperInvoiceCount) InvPostPSp(
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
			string pMooreForms = "N",
			string TInvNum = "0",
			string StartInvNum = null,
			string EndInvNum = null,
			string Infobar = null,
			Guid? ProcessId = null,
			int? InvoiceCount = 0,
			int? EDINoPaperInvoiceCount = 0,
			string CalledFrom = null,
			Guid? InvoicBuilderProcessID = null);
	}
}

