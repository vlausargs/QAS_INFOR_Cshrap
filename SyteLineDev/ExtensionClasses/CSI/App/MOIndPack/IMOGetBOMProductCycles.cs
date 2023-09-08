//PROJECT NAME: MOIndPack
//CLASS NAME: IMOGetBOMProductCycles.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMOGetBOMProductCycles
	{
		long? MOGetBOMProductCyclesFn(
			string CoNum);
	}
}

