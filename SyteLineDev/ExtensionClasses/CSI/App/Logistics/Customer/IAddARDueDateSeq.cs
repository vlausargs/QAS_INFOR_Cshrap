//PROJECT NAME: Logistics
//CLASS NAME: IAddARDueDateSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAddARDueDateSeq
	{
		(int? ReturnCode, string Infobar) AddARDueDateSeqSp(string pCustNum,
		string pInvNum,
		int? pInvSeq,
		DateTime? pInvoiceDate,
		string pTermsCode,
		int? pMultiDueDateFlag,
		string Infobar);
	}
}

