//PROJECT NAME: Production
//CLASS NAME: IJobReceiptValidateJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobReceiptValidateJob
	{
			(int? ReturnCode,
			int? JobrouteOperNum,
			decimal? QtyMoved,
			decimal? QtyComplete,
			int? ItemLotTracked,
			int? ItemSerialTracked,
			string Infobar,
			string Prompt,
			string PromptButtons) 
		JobReceiptValidateJobSp(
			string Job,
			int? Suffix,
			int? JobrouteOperNum,
			decimal? QtyMoved,
			decimal? QtyComplete,
			int? ItemLotTracked,
			int? ItemSerialTracked,
			string Infobar,
			string Prompt = null,
			string PromptButtons = null);
	}
}

