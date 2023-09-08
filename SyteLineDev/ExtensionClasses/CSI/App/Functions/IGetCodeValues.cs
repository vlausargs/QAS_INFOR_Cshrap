//PROJECT NAME: Data
//CLASS NAME: IGetCodeValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCodeValues
	{
		ICollectionLoadResponse GetCodeValuesFn(
			string Class);
	}
}

