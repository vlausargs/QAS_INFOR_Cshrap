//PROJECT NAME: Logistics
//CLASS NAME: ISchedGetPermissionsSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedGetPermissions
	{
		ICollectionLoadResponse SchedGetPermissionsSp(
			string Username);
	}
}

