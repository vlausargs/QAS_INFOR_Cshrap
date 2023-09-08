//PROJECT NAME: Data
//CLASS NAME: IParseCycleType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IParseCycleType
	{
		int? ParseCycleTypeFn(
			string CycleTypeIn,
			string CycleType);
	}
}

