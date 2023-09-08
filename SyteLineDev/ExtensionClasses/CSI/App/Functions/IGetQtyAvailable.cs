//PROJECT NAME: Data
//CLASS NAME: IGetQtyAvailable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetQtyAvailable
	{
		string GetQtyAvailableFn(
			string Item,
			int? LocaleID,
			string Site);
	}
}

