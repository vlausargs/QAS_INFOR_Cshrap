//PROJECT NAME: Production
//CLASS NAME: IValidateJobSuffix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateJobSuffix
	{
		(int? ReturnCode, string JobSuffix,
		string JobStat,
		decimal? QtyReleasesd,
		string JobItem,
		int? CoProductMix,
		string ItmDescription,
		string Infobar) ValidateJobSuffixSp(string Job,
		int? Suffix,
		string JobSuffix,
		string JobStat,
		decimal? QtyReleasesd,
		string JobItem,
		int? CoProductMix,
		string ItmDescription,
		string Infobar);
	}
}

