//PROJECT NAME: Production
//CLASS NAME: IUpdateResourceSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IUpdateResourceSched
	{
		int? UpdateResourceSchedSp(int? SequenceNum,
		int? JobTag,
		string GroupID);
	}
}

