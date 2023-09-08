//PROJECT NAME: Data
//CLASS NAME: IGetIDOCollectionNames.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetIDOCollectionNames
	{
		ICollectionLoadResponse GetIDOCollectionNamesFn(
			string IDO_Name);
	}
}

