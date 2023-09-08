//PROJECT NAME: Production
//CLASS NAME: IProcplnIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IProcplnIns
	{
		int? ProcplnInsSp(string Procplan,
		string Descr,
		string Effect,
		string SchedOnlyFg,
		int? AltNo);
	}
}

