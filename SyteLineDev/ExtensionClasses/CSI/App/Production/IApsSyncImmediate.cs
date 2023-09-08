//PROJECT NAME: Production
//CLASS NAME: IApsSyncImmediate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IApsSyncImmediate
	{
		(int? ReturnCode, string Infobar) ApsSyncImmediateSp(string Infobar,
		int? DropDeferred = 0,
		string Context = null);
	}
}

