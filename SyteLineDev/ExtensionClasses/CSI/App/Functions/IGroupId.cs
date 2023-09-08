//PROJECT NAME: Data
//CLASS NAME: IGroupIdSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGroupId
	{
		decimal? GroupIdSp(
			string Groupname);
	}
}

