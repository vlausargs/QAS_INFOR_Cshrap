//PROJECT NAME: Data
//CLASS NAME: IDisplayWhseAddressWithPhoneSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayWhseAddressWithPhone
	{
		string DisplayWhseAddressWithPhoneSp(
			string Whse,
			string SiteRef);
	}
}

