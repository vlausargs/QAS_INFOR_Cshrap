//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPartReimbProcessSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPartReimbProcessSub
	{
		(int? ReturnCode,
			decimal? ReimbTot,
			decimal? ReimbTotTax,
			string Infobar) SSSFSPartReimbProcessSubSp(
			string ReimbMethod,
			string VendCatEndUserType,
			string VendNum,
			Guid? SessionID,
			string BatchId,
			decimal? MiscCharges,
			decimal? AmtDue,
			decimal? ReimbTot,
			decimal? ReimbTotTax,
			string Infobar);
	}
}

