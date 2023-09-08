//PROJECT NAME: Codes
//CLASS NAME: IList_DimCatTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IList_DimCatTable
	{
		(ICollectionLoadResponse Data, int? ReturnCode) List_DimCatTableSp(Guid? TableRowPointer,
		string objectName,
		string Dimension);
	}
}

