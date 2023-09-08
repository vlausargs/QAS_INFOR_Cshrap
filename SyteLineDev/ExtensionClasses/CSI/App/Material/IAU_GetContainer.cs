//PROJECT NAME: Material
//CLASS NAME: IAU_GetContainer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IAU_GetContainer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) AU_GetContainerSp(string Whse,
		string RefType);
	}
}

