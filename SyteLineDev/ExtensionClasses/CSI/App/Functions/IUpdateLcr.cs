//PROJECT NAME: Data
//CLASS NAME: IUpdateLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateLcr
	{
		(int? ReturnCode,
			string Infobar) UpdateLcrSp(
			string CoNum,
			string CustNum,
			int? AddAccum,
			string LcrNum,
			string Infobar,
			decimal? OldTotalPrice = null,
			decimal? OldShipPrice = null);
	}
}

