//PROJECT NAME: Production
//CLASS NAME: IProcplnDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IProcplnDel
	{
		int? ProcplnDelSp(string Procplan,
		int? AltNo);
	}
}

