//PROJECT NAME: Data
//CLASS NAME: IIsUserInGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsUserInGroup
	{
		int? IsUserInGroupFn(
			string Username,
			string GroupName);
	}
}

