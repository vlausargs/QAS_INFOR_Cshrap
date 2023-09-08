//PROJECT NAME: Data
//CLASS NAME: IConvertInvoiceNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertInvoiceNum
	{
		(int? ReturnCode,
			string Infobar) ConvertInvoiceNumSp(
			int? InvLength,
			string Infobar);
	}
}

