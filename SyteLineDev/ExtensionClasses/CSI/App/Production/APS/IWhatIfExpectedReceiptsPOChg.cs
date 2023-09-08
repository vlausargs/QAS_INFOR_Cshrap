//PROJECT NAME: Production
//CLASS NAME: IWhatIfExpectedReceiptsPOChg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IWhatIfExpectedReceiptsPOChg
	{
		(int? ReturnCode, DateTime? DueDate,
		string QtyOrdered) WhatIfExpectedReceiptsPOChgSp(int? AltNo,
		string PONum = null,
		DateTime? DueDate = null,
		string QtyOrdered = null);
	}
}

