//PROJECT NAME: Production
//CLASS NAME: IApsSyncDefer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IApsSyncDefer
	{
		(int? ReturnCode, string Infobar) ApsSyncDeferSp(string Infobar,
		string Context = null);
	}
}

