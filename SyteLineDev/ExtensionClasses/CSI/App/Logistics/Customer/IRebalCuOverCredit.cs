//PROJECT NAME: Logistics
//CLASS NAME: IRebalCuOverCredit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRebalCuOverCredit
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RebalCuOverCreditSp(string StartCustNum,
		string EndCustNum,
		string Infobar,
		string SiteGroup = null);
	}
}

