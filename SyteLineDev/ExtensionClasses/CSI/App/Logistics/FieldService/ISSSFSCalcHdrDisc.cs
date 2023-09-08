//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSCalcHdrDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCalcHdrDisc
	{
		decimal? SSSFSCalcHdrDiscFn(
			decimal? Amount,
			decimal? OrdDisc,
			int? Places);
	}
}

