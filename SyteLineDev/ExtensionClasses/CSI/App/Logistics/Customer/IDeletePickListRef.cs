//PROJECT NAME: Logistics
//CLASS NAME: IDeletePickListRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IDeletePickListRef
	{
		(int? ReturnCode, string Infobar) DeletePickListRefSp(decimal? PickListId,
		Guid? RefRowPointer,
		string Infobar);
	}
}

