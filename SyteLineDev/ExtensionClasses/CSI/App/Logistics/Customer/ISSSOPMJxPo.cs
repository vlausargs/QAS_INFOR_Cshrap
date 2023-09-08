//PROJECT NAME: Logistics
//CLASS NAME: ISSSOPMJxPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSOPMJxPo
	{
		(int? ReturnCode,
			string PAction,
			string Infobar) SSSOPMJxPoSp(
			string PPoNum,
			int? PPoLine,
			int? PPoRelease,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			int? PPoChangeOrd,
			decimal? PQtyMoved,
			string PPartialMethod,
			string PAction,
			string Infobar);
	}
}

