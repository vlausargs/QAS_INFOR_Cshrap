//PROJECT NAME: Data
//CLASS NAME: IGetDefEc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetDefEc
	{
		string GetDefEcFn(
			string VendNum);
	}
}

