//PROJECT NAME: Data
//CLASS NAME: ISalespersonCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISalespersonCodes
	{
		string SalespersonCodesFn(
			string RefNum,
			int? Outside);
	}
}

