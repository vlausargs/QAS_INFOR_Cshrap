//PROJECT NAME: Data
//CLASS NAME: IGetSsl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSsl
	{
		string GetSslFn(
			string CoNum,
			string CoType);
	}
}

