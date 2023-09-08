//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBMXProcessInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBMXProcessInvoice
	{
		(int? ReturnCode,
			string Infobar) LoadESBMXProcessInvoiceSp(
			string ActionExpression = null,
			string ProcessInvoice = null,
			string UUID = null,
			string Status = null,
			string ErrMessage = null,
			string FileName = null,
			string Infobar = null);
	}
}

