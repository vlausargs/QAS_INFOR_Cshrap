//PROJECT NAME: Data
//CLASS NAME: IGetItemCompliantStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemCompliantStat
	{
		int? GetItemCompliantStatFn(
			string item,
			string ComplianceProgramId);
	}
}

