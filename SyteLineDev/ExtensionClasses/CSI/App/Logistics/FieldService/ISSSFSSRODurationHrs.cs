//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSRODurationHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSRODurationHrs
	{
		decimal? SSSFSSRODurationHrsFn(
			string iSRONum,
			int? iSROLine = null,
			int? iSROOper = null,
			int? iCalcFrom = 0);
	}
}

