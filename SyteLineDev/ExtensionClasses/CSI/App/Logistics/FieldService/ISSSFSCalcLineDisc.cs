//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCalcLineDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCalcLineDisc
	{
		decimal? SSSFSCalcLineDiscFn(
			decimal? Amount,
			decimal? LineDisc,
			int? Places);
	}
}

