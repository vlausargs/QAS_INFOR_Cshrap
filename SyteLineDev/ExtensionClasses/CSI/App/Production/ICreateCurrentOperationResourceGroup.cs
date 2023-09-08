//PROJECT NAME: Production
//CLASS NAME: ICreateCurrentOperationResourceGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICreateCurrentOperationResourceGroup
	{
		(int? ReturnCode,
			string Infobar) CreateCurrentOperationResourceGroupSp(
			string Item,
			int? JrtResGroupOperNum,
			string JrtResGroupRgid,
			int? JrtResGroupQtyResources,
			string JrtResGroupResactn,
			int? JrtResGroupSequence,
			string Infobar);
	}
}

