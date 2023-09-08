//PROJECT NAME: Production
//CLASS NAME: IRgrpMbrsDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IRgrpMbrsDel
	{
		int? RgrpMbrsDelSp(Guid? Rowp,
		string PRgrp,
		string PRes,
		int? AltNo);
	}
}

