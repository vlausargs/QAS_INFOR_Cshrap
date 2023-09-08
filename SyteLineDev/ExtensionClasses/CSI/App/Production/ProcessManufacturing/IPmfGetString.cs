//PROJECT NAME: Production
//CLASS NAME: IPmfGetString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetString
	{
		(int? ReturnCode,
			string Result) PmfGetStringSp(
			string StringId,
			string Result = null);
	}
}

