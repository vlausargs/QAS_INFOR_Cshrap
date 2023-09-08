//PROJECT NAME: Data
//CLASS NAME: IGetJobValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobValues
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
			string Infobar) GetJobValuesSp(
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

