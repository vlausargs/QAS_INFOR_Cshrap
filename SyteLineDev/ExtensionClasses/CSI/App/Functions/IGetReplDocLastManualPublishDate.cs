//PROJECT NAME: Data
//CLASS NAME: IGetReplDocLastManualPublishDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetReplDocLastManualPublishDate
	{
		DateTime? GetReplDocLastManualPublishDateFn(
			string AppliesToIDOName,
			string AppliesToIDOAction,
			string AppliesToIDOMethodName);
	}
}

