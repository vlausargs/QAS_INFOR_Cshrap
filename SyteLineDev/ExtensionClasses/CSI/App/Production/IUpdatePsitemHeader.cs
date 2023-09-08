//PROJECT NAME: Production
//CLASS NAME: IUpdatePsitemHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IUpdatePsitemHeader
	{
		int? UpdatePsitemHeaderSp(string Job,
		string JobWhse,
		string JobRevision);
	}
}

