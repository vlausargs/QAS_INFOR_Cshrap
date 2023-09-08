//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubProjSRO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubProjSRO
	{
		(int? ReturnCode,
			int? TInvLine,
			decimal? SroOperTot,
			string Infobar) SSSFSSROInvSubProjSROSp(
			string Mode,
			string SRONum,
			int? SROLine,
			int? SROOper,
			string InvNum,
			int? TInvLine,
			DateTime? StartTransDate,
			DateTime? EndTransDate,
			decimal? SroOperTot,
			string Infobar,
			string VTXRefType,
			Guid? VTXHdrRowPointer);
	}
}

