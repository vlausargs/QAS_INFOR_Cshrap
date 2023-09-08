//PROJECT NAME: Data
//CLASS NAME: IMinsToHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMinsToHrs
	{
		string MinsToHrsFn(
			int? TimeMins);
	}
}

