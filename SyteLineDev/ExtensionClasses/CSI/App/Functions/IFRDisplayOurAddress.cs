//PROJECT NAME: Data
//CLASS NAME: IFRDisplayOurAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFRDisplayOurAddress
	{
		string FRDisplayOurAddressFn(
			string FRMessageLanguage = null);
	}
}

