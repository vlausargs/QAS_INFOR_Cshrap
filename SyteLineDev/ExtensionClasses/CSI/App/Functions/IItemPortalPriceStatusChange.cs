//PROJECT NAME: Data
//CLASS NAME: IItemPortalPriceStatusChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemPortalPriceStatusChange
	{
		(int? ReturnCode,
			string Infobar) ItemPortalPriceStatusChangeSp(
			string Infobar = null);
	}
}

