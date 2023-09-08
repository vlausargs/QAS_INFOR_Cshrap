//PROJECT NAME: Data
//CLASS NAME: IPortalPricingOptionsExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalPricingOptionsExist
	{
		int? PortalPricingOptionsExistFn(
			string Item,
			string CustNum);
	}
}

