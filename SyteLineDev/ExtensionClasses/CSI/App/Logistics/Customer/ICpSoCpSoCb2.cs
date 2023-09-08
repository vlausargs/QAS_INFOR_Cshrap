//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoCb2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoCb2
	{
		(int? ReturnCode,
			string Infobar) CpSoCpSoCb2Sp(
			string pCoNum,
			int? pCoLine,
			decimal? pContPriceConv,
			decimal? pContPrice,
			string Infobar);
	}
}

