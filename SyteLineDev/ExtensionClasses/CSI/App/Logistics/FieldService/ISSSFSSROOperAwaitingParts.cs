//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROOperAwaitingParts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROOperAwaitingParts
	{
		int? SSSFSSROOperAwaitingPartsFn(
			string iSRONum,
			int? iSROLine = null,
			int? iSROOper = null);
	}
}

