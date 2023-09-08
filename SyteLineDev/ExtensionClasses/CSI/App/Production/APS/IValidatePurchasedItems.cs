//PROJECT NAME: Production
//CLASS NAME: IValidatePurchasedItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IValidatePurchasedItems
	{
		(int? ReturnCode, string Infobar) ValidatePurchasedItemsSp(string ItemNum, string Infobar);
	}
}

