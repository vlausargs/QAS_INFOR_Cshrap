//PROJECT NAME: Data
//CLASS NAME: IGetItemSurcharge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemSurcharge
	{
		(int? ReturnCode,
			decimal? SumSurcharge) GetItemSurchargeSp(
			string Item = null,
			string RefType = null,
			string RefNum = null,
			int? RefLine = 0,
			int? RefRelease = 0,
			string InvNum = null,
			DateTime? TransDate = null,
			string RefItemContent = null,
			decimal? SumSurcharge = null);

		decimal? GetItemSurchargeFn(
			string Item = null,
			string RefType = null,
			string RefNum = null,
			int? RefLine = 0,
			int? RefRelease = 0,
			string InvNum = null,
			DateTime? TransDate = null,
			string RefItemContent = null);
	}
}

