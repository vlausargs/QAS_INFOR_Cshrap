//PROJECT NAME: Data
//CLASS NAME: IUpdateStatistics.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateStatistics
	{
		int? UpdateStatisticsSp(
			string DatabaseName = null);
	}
}

