//PROJECT NAME: Production
//CLASS NAME: IPmfGetPrimaryViewName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetPrimaryViewName
	{
		string PmfGetPrimaryViewNameFn(
			string Tablename);
	}
}

