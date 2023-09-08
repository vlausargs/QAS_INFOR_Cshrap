//PROJECT NAME: Data
//CLASS NAME: IGetReplIDOCollection.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetReplIDOCollection
	{
		string GetReplIDOCollectionFn(
			string Property,
			string Parsing);
	}
}

