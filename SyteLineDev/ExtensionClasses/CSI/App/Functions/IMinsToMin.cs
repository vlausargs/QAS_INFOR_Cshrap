//PROJECT NAME: Data
//CLASS NAME: IMinsToMin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMinsToMin
	{
		string MinsToMinFn(
			int? TimeMins);
	}
}

