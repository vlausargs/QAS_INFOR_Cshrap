//PROJECT NAME: Production
//CLASS NAME: IEngWBUpdateResourceGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IEngWBUpdateResourceGroup
	{
		(int? ReturnCode, string Infobar) EngWBUpdateResourceGroupSp(string Job,
		int? Suffix,
		int? OperNum,
		string UpdateResourceGroupFrom = null,
		Guid? FromJobRouteRowPointer = null,
		string Infobar = null);
	}
}

