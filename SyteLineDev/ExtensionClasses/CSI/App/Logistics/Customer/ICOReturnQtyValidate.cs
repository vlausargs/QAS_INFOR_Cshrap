//PROJECT NAME: Logistics
//CLASS NAME: ICOReturnQtyValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICOReturnQtyValidate
	{
		(int? ReturnCode,
		string Infobar) COReturnQtyValidateSp(
			string CoitemCoNum,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string SDoNum,
			int? SDoLine,
			decimal? SQty,
			int? SReturn,
			string SLoc,
			string SLot,
			int? PackNum = null,
			int? LotTrack = null,
			string Infobar = null);
	}
}

