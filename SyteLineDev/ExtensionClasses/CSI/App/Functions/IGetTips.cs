//PROJECT NAME: Data
//CLASS NAME: IGetTips.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTips
	{
		(int? ReturnCode,
			decimal? tips) GetTipsSp(
			string de_code,
			decimal? de_amt,
			decimal? tips = null);
	}
}

