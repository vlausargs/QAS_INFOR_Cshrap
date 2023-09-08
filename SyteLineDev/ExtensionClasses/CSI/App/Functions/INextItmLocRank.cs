//PROJECT NAME: Data
//CLASS NAME: INextItmLocRank.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextItmLocRank
	{
		int? NextItmLocRankFn(
			string Whse,
			string Item);
	}
}

