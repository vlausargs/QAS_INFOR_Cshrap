//PROJECT NAME: Production
//CLASS NAME: IRgrpMbrsIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IRgrpMbrsIns
	{
		int? RgrpMbrsInsSp(string PRgrp,
		string PRes,
		int? Seqno,
		int? AltNo);
	}
}

