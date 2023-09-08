//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubCalcSROLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubCalcSROLine
	{
		(int? ReturnCode,
			int? InvLine,
			decimal? SroLineMatlTot,
			string Infobar) SSSFSSROInvSubCalcSROLineSp(
			string Mode,
			int? InclBillHold,
			string SRONum,
			int? SROLine,
			string InvNum,
			int? InvLine,
			decimal? SroLineMatlTot,
			DateTime? StartTransDate,
			DateTime? EndTransDate,
			string Infobar,
			string VTXRefType,
			Guid? VTXHdrRowPointer);
	}
}

