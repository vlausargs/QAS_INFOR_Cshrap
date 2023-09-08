//PROJECT NAME: Finance
//CLASS NAME: IGetVATTrxn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetVATTrxn
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetVATTrxnSp(string PeriodKey,
		string BoxNum,
		string TaxJur,
		int? TaxSystem = 1,
		string FilterSite = null);
	}
}

