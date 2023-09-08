//PROJECT NAME: Production
//CLASS NAME: IJoblow.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJoblow
	{
		(ICollectionLoadResponse Data, int? ReturnCode) JoblowSp(string PList,
		int? BgTaskID = null);
	}
}

