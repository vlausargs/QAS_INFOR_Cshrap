//PROJECT NAME: Data
//CLASS NAME: IDisplayWhseAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayWhseAddress
	{
		string DisplayWhseAddressSp(
			string Whse,
			string SiteRef);
	}
}

