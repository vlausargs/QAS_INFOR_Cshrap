//PROJECT NAME: Data
//CLASS NAME: IPullReplData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPullReplData
	{
		int? PullReplDataSp(
			string SpName,
			Guid? SessionID);
	}
}

