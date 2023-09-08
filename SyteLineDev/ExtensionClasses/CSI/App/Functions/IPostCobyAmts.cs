//PROJECT NAME: Data
//CLASS NAME: IPostCobyAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPostCobyAmts
	{
		(int? ReturnCode,
			string Infobar) PostCobyAmtsSp(
			string SJobProdMix,
			string SJobrouteJob,
			int? SJobrouteSuffix,
			int? SJobrouteOperNum,
			decimal? SJobtranTransNum,
			decimal? SJobtranFixovhd,
			decimal? SJobtranVarovhd,
			string Infobar);
	}
}

