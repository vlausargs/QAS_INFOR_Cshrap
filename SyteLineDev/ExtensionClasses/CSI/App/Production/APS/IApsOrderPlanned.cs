//PROJECT NAME: Production
//CLASS NAME: IApsOrderPlanned.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsOrderPlanned
	{
		int? ApsOrderPlannedSp(
			int? AltNo,
			string Item);
	}
}

