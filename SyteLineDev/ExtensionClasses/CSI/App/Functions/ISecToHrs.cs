//PROJECT NAME: Data
//CLASS NAME: ISecToHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISecToHrs
	{
		string SecToHrsFn(
			int? TimeSec);
	}
}

