//PROJECT NAME: Data
//CLASS NAME: IEdiGenGetItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiGenGetItem
	{
		(int? ReturnCode,
			int? PError,
			Guid? PItemRecid,
			Guid? PItemcustRecid) EdiGenGetItemSp(
			string PItem,
			string PCustNum,
			string PCustItem,
			int? PError,
			Guid? PItemRecid,
			Guid? PItemcustRecid);
	}
}

