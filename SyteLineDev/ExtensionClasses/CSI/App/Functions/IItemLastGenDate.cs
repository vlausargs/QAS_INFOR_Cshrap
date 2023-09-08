//PROJECT NAME: Data
//CLASS NAME: IItemLastGenDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemLastGenDate
	{
		DateTime? ItemLastGenDateFn(
			DateTime? ItemChangeDate);
	}
}

