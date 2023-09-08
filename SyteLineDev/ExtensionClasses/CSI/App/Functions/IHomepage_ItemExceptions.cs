//PROJECT NAME: Data
//CLASS NAME: IHomepage_ItemExceptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHomepage_ItemExceptions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_ItemExceptionsSp(
			DateTime? Date);
	}
}

