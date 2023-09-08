//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROSum
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROSumSp(
			string InSroNum,
			int? InSroLine,
			int? InSroOper,
			int? InSetSro,
			int? InSetLine,
			int? PreventOverride = 0,
			int? CalledFromInvoicing = 0,
			string Infobar = null);
	}
}

