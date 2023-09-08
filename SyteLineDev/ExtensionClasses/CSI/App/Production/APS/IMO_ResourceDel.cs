//PROJECT NAME: Production
//CLASS NAME: IMO_ResourceDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IMO_ResourceDel
	{
		int? MO_ResourceDelSp(string RESID, int? AltNo);
	}
}

