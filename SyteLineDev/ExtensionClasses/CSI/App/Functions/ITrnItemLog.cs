//PROJECT NAME: Data
//CLASS NAME: ITrnItemLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrnItemLog
	{
		(int? ReturnCode,
			string Infobar) TrnItemLogSp(
			string PTrnNum,
			int? PTrnLine,
			string PItem,
			string OldItem,
			decimal? POldQtyReqConv,
			decimal? PNewQtyReqConv,
			DateTime? POldSchShipDate,
			DateTime? PNewSchShipDate,
			DateTime? POldSchRcvDate,
			DateTime? PNewSchRcvDate,
			string POldTrnLoc,
			string PNewTrnLoc,
			string PAction,
			decimal? PUomConvFactor,
			string POldUM,
			string PNewUM,
			string Infobar);
	}
}

