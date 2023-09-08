//PROJECT NAME: Admin
//CLASS NAME: IGetTableStatistics.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IGetTableStatistics
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetTableStatisticsSp(string filterString = null,
		string DatabaseName = null,
		string pSite = null);
	}
}

