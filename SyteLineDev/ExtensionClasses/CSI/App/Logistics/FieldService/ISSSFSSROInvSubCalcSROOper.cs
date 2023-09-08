//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubCalcSROOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubCalcSROOper
	{
		(int? ReturnCode,
			int? InvLine,
			decimal? SroOperTot,
			string Infobar) SSSFSSROInvSubCalcSROOperSp(
			string Mode,
			int? InclBillHold,
			string SRONum,
			int? SROLine,
			int? SROOper,
			string InvNum,
			int? InvLine,
			DateTime? StartTransDate,
			DateTime? EndTransDate,
			decimal? SroOperTot,
			string Infobar,
			string VTXRefType,
			Guid? VTXHdrRowPointer);
	}
}

