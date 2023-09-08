//PROJECT NAME: Data
//CLASS NAME: IGetNextCurrateDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetNextCurrateDate
	{
		DateTime? GetNextCurrateDateFn(
			DateTime? TransDate = null,
			string ForCurrCode = null,
			string DomCurrCode = null);
	}
}

