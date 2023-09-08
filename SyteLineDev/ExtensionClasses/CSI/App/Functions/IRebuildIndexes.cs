//PROJECT NAME: Data
//CLASS NAME: IRebuildIndexes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRebuildIndexes
	{
		int? RebuildIndexesSp(
			string DatabaseName = null);
	}
}

