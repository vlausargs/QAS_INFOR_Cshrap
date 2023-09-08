//PROJECT NAME: Data
//CLASS NAME: IIsStdItemBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsStdItemBOM
	{
		int? IsStdItemBOMFn(
			string Item,
			int? Suffix);
	}
}

