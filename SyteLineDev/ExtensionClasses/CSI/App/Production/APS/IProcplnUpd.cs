//PROJECT NAME: Production
//CLASS NAME: IProcplnUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IProcplnUpd
	{
		int? ProcplnUpdSp(string Procplan,
		string Descr,
		string Effect,
		string SchedOnlyFg,
		int? AltNo);
	}
}

