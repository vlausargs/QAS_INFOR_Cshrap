//PROJECT NAME: Admin
//CLASS NAME: IBI_GetIDOCollectionNames.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IBI_GetIDOCollectionNames
	{
		ICollectionLoadResponse BI_GetIDOCollectionNamesFn(
			string IDO_Name);
	}
}

