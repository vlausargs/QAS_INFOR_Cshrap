//PROJECT NAME: Admin
//CLASS NAME: ILoadActiveFeatureList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ILoadActiveFeatureList
	{
		(int? ReturnCode, string ActiveFeatureList) LoadActiveFeatureListSp(string ProductName = "CSI",
		string ActiveFeatureList = null);
	}
}

