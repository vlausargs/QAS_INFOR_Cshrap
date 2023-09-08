//PROJECT NAME: Data
//CLASS NAME: IFRDisplayOurAddressSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFRDisplayOurAddressSite
	{
		string FRDisplayOurAddressSiteFn(
			string SiteRef,
			string FRMessageLanguage = null);
	}
}

