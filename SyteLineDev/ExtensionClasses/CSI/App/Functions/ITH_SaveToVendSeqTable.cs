//PROJECT NAME: Data
//CLASS NAME: ITH_SaveToVendSeqTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITH_SaveToVendSeqTable
	{
		int? TH_SaveToVendSeqTableSp(
			string VendorNum = null,
			int? voucher = null,
			DateTime? InvDate = null,
			string vendinv = null,
			string whtseq = null,
			Guid? ThapptcdRp = null);
	}
}

