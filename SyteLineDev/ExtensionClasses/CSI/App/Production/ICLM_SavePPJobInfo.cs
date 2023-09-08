//PROJECT NAME: Production
//CLASS NAME: ICLM_SavePPJobInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_SavePPJobInfo
	{
		(int? ReturnCode, string Infobar) CLM_SavePPJobInfoSp(int? ProdBatchId,
		decimal? MinSheetCount,
		decimal? PrintQuatePrice,
		decimal? PaperConsumptionQty,
		int? Out,
		int? Up,
		int? IsNeedAddppJob,
		string Infobar);
	}
}

