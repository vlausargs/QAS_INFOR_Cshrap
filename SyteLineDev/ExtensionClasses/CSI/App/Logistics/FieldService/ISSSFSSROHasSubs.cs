//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROHasSubs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROHasSubs
	{
		(int? ReturnCode,
			int? SROLine,
			int? SROOper,
			int? HasMatl,
			int? HasLabor,
			int? HasMisc,
			int? HasLineMatl,
			int? HasInv,
			int? HasDeposit,
			string Infobar) SSSFSSROHasSubsSp(
			string SRONum,
			int? SROLine,
			int? SROOper,
			int? HasMatl,
			int? HasLabor,
			int? HasMisc,
			int? HasLineMatl,
			int? HasInv,
			int? HasDeposit,
			string Infobar);
	}
}

