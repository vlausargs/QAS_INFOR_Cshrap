//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoCb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoCb
	{
		(int? ReturnCode,
			string Infobar) CpSoCpSoCbSp(
			string PFromCoType,
			string PFromCoNum,
			int? PFromCoLine,
			string PFromCurr,
			string PToCoNum,
			int? PToCoLine,
			string PToCoOrigSite,
			string PToCurr,
			int? IsCrossSite,
			int? PCopyShipSiteCo,
			int? PToNew,
			int? PHasCfg,
			string Infobar);
	}
}

