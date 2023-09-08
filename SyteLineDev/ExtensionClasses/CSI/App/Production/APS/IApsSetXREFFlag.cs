//PROJECT NAME: Production
//CLASS NAME: IApsSetXREFFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSetXREFFlag
	{
		int? ApsSetXREFFlagFn(
			string SupplyRefType,
			string SupplyRefNum,
			int? SupplyRefLineSuf,
			int? SupplyRefRelease,
			string DemandRefType,
			string DemandRefNum,
			int? DemandRefLineSuf,
			int? DemandRefRelease,
			int? DemandSequence,
			string Item);
	}
}

