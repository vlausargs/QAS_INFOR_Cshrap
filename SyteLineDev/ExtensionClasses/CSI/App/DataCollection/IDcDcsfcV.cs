//PROJECT NAME: DataCollection
//CLASS NAME: IDcDcsfcV.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcDcsfcV
	{
		(int? ReturnCode,
			DateTime? PPostDate,
			int? PCanOverride,
			string Infobar) DcDcsfcVSp(
			Guid? DcsfcRowPointer,
			Guid? JobtranRowPointer,
			decimal? PAHrs,
			int? PStartTime,
			int? PEndTime,
			decimal? PJobRate,
			decimal? PQtyComplete,
			decimal? PQtyScrapped,
			decimal? PQtyMoved,
			int? PCompleteOp,
			decimal? PPrRate,
			string PPayRate,
			int? PCoprodZero,
			DateTime? PPostDate,
			int? PCanOverride,
			string Infobar);
	}
}

