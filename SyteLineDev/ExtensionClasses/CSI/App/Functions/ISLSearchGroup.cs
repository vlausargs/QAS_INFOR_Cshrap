//PROJECT NAME: Data
//CLASS NAME: ISLSearchGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISLSearchGroup
	{
		(int? ReturnCode,
			string ResultSet,
			string InfobarType) SLSearchGroupSp(
			string GetorSearchList,
			string emailid,
			string ResultSet,
			string InfobarType);
	}
}

