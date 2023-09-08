//PROJECT NAME: Production
//CLASS NAME: IPmfStrToken.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfStrToken
	{
		string PmfStrTokenFn(
			string str,
			string delim,
			int? findN);
	}
}

