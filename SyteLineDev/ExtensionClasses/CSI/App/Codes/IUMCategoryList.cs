//PROJECT NAME: Codes
//CLASS NAME: IUMCategoryList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IUMCategoryList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) UMCategoryListSp();
	}
}

