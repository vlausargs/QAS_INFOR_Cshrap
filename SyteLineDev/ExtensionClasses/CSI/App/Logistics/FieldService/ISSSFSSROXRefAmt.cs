//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROXRefAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROXRefAmt
	{
		(int? ReturnCode,
			decimal? PQtyAvail,
			string Infobar,
			int? POError) SSSFSSROXRefAmtSP(
			string PRefType = null,
			string PRefNum = null,
			int? PRefLine = null,
			int? PRefRel = null,
			string PItem = null,
			decimal? PQtyAvail = null,
			string Infobar = null,
			int? POError = 0);
	}
}

