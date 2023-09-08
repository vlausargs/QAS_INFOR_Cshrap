//PROJECT NAME: Data
//CLASS NAME: IGetSplitWhitespace.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSplitWhitespace
	{
		int? GetSplitWhitespaceFn(
			string Desc,
			int? SplitNum);
	}
}

