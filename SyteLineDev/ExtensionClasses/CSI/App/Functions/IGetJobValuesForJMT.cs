//PROJECT NAME: Data
//CLASS NAME: IGetJobValuesForJMT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobValuesForJMT
	{
		(int? ReturnCode,
			int? InSuffix,
			int? JobCoProdMix,
			string JobOrdType,
			string JobItem,
			string JobWhse,
			string JobRootJob,
			int? JobRootSuf,
			string JobRefJob,
			string JobStat,
			string JobType,
			string Infobar) GetJobValuesForJMTSp(
			string InJob,
			int? InSuffix,
			int? JobCoProdMix,
			string JobOrdType,
			string JobItem,
			string JobWhse,
			string JobRootJob,
			int? JobRootSuf,
			string JobRefJob,
			string JobStat,
			string JobType,
			string Infobar);
	}
}

