//PROJECT NAME: Logistics
//CLASS NAME: ILcTaxDistributionCustUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ILcTaxDistributionCustUpd
	{
		int? LcTaxDistributionCustUpdSp(int? TaxSystem,
		string TaxCode,
		string TaxCodeE,
		decimal? AmtTaxBasis,
		decimal? AmtTaxAmount);
	}
}

