//PROJECT NAME: Data
//CLASS NAME: IDisplayOurAddressSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayOurAddressSite
	{
		string DisplayOurAddressSiteFn(
			string SiteRef);
	}
}

