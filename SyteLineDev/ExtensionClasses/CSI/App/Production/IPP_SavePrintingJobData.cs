//PROJECT NAME: Production
//CLASS NAME: IPP_SavePrintingJobData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_SavePrintingJobData
	{
		(int? ReturnCode, string Infobar) PP_SavePrintingJobDataSp(string Job,
		int? Suffix,
		decimal? MinSheetCount,
		decimal? PrintQuotePrice,
		int? Up,
		int? Out,
		string Infobar);
	}
}

