//PROJECT NAME: Production
//CLASS NAME: IPmfIsNumeric.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfIsNumeric
	{
		bool? PmfIsNumericFn(
			string num);
	}
}

