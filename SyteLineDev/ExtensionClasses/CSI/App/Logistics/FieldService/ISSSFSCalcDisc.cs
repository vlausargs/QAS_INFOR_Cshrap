//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCalcDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCalcDisc
	{
		decimal? SSSFSCalcDiscFn(
			decimal? Amount,
			decimal? OrdDisc,
			decimal? LineDisc,
			int? Places);
	}
}

