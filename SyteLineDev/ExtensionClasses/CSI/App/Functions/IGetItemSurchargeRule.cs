//PROJECT NAME: Data
//CLASS NAME: IGetItemSurchargeRuleSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemSurchargeRule
	{
		ICollectionLoadResponse GetItemSurchargeRuleSp(
			string RefType = null,
			string RefNum = null,
			int? RefLine = 0,
			int? RefRelease = 0,
			string InvNum = null,
			DateTime? TransDate = null);
	}
}

