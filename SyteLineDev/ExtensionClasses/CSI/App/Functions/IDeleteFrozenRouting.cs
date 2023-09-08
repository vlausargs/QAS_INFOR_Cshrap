//PROJECT NAME: Data
//CLASS NAME: IDeleteFrozenRouting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteFrozenRouting
	{
		(int? ReturnCode,
			string Infobar) DeleteFrozenRoutingSp(
			string Item,
			string Job,
			string Infobar);
	}
}

