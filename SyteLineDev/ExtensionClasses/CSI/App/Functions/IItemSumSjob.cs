//PROJECT NAME: Data
//CLASS NAME: IItemSumSjob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemSumSjob
	{
		(int? ReturnCode,
			string Infobar) ItemSumSjobSp(
			string Item,
			string Infobar);
	}
}

