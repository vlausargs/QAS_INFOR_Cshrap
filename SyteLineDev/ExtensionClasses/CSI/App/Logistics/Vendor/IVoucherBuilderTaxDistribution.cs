//PROJECT NAME: Logistics
//CLASS NAME: IVoucherBuilderTaxDistribution.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherBuilderTaxDistribution
	{
		(int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) VoucherBuilderTaxDistributionSp(
			Guid? PProcessId,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar,
			string ParmsSite);
	}
}

