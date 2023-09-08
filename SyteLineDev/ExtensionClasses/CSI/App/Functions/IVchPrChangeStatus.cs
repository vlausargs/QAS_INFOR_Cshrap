//PROJECT NAME: Data
//CLASS NAME: IVchPrChangeStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVchPrChangeStatus
	{
		(int? ReturnCode,
			string Infobar) VchPrChangeStatusSp(
			Guid? RowPointer,
			int? PreRegister,
			string Stat,
			DateTime? Date,
			DateTime? VchDate,
			string VendNum,
			decimal? MatlCost,
			decimal? Freight,
			decimal? MiscCharges,
			decimal? SalesTax,
			decimal? SalesTax_2,
			decimal? ExchRate,
			string SuspenseAcct,
			string SuspenseAcctUnit1,
			string SuspenseAcctUnit2,
			string SuspenseAcctUnit3,
			string SuspenseAcctUnit4,
			string UnmatchedAcct,
			string UnmatchedAcctUnit1,
			string UnmatchedAcctUnit2,
			string UnmatchedAcctUnit3,
			string UnmatchedAcctUnit4,
			string FreightAcct,
			string FreightAcctUnit1,
			string FreightAcctUnit2,
			string FreightAcctUnit3,
			string FreightAcctUnit4,
			string MiscAcct,
			string MiscAcctUnit1,
			string MiscAcctUnit2,
			string MiscAcctUnit3,
			string MiscAcctUnit4,
			string Infobar);
	}
}

