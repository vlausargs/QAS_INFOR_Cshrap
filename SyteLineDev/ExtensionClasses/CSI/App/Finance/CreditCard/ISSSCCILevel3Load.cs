//PROJECT NAME: Finance
//CLASS NAME: ISSSCCILevel3Load.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCILevel3Load
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSCCILevel3LoadSp(
			string InvNum,
			decimal? PayAmt);
	}
}

