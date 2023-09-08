//PROJECT NAME: Production
//CLASS NAME: IApsGetGroupMemberCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetGroupMemberCount
	{
		int? ApsGetGroupMemberCountFn(
			string Group);
	}
}

