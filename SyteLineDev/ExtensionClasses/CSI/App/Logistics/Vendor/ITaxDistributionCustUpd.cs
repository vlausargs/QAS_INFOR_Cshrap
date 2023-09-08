//PROJECT NAME: Logistics
//CLASS NAME: ITaxDistributionCustUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITaxDistributionCustUpd
	{
		int? TaxDistributionCustUpdSp(string VchType,
		string PoNum,
		int? TaxSystem,
		string TaxCode,
		string TaxCodeE,
		decimal? AmtTaxBasis,
		decimal? AmtTaxAmount);
	}
}

