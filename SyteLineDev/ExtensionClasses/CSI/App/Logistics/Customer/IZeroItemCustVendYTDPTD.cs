//PROJECT NAME: Logistics
//CLASS NAME: IZeroItemCustVendYTDPTD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IZeroItemCustVendYTDPTD
	{
		(int? ReturnCode, int? ItemvendCount,
		int? ItemcustCount) ZeroItemCustVendYTDPTDSp(int? ZeroItemvendYTD,
		int? ZeroItemcustPTD,
		int? ZeroItemcustYTD,
		string BegItem,
		string EndItem,
		int? ItemvendCount,
		int? ItemcustCount);
	}
}

