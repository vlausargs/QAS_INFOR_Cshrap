//PROJECT NAME: Production
//CLASS NAME: IApsOrderDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsOrderDel
	{
		int? ApsOrderDelSp(Guid? Rowp,
		string POrd,
		int? AltNo);
	}
}

