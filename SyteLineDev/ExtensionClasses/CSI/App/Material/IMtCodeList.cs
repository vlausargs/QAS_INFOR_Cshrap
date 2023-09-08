//PROJECT NAME: Material
//CLASS NAME: IMtCodeList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMtCodeList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MtCodeListSp();
	}
}

