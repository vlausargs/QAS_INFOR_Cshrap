//PROJECT NAME: Data
//CLASS NAME: IDisplayOfficeAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayOfficeAddress
	{
		string DisplayOfficeAddressSp(
			string LcnNo);
	}
}

