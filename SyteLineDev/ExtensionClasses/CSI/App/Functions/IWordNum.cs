//PROJECT NAME: Data
//CLASS NAME: IWordNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWordNum
	{
		(int? ReturnCode,
			string WordL1,
			string Infobar) WordNumSp(
			decimal? Digits,
			int? Places,
			string PCurrCode,
			string WordL1,
			string Infobar);
	}
}

