//PROJECT NAME: POS
//CLASS NAME: IFormatAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface IFormatAddress
	{
		(int? ReturnCode, string BillToAddress,
		string ShipToAddress,
		string Infobar) FormatAddressSp(string CustNum,
		int? CustSeq,
		string BillToAddress,
		string ShipToAddress,
		string Infobar);

		string FormatAddressFn(
			string CustNum,
			int? CustSeq);
	}
}

