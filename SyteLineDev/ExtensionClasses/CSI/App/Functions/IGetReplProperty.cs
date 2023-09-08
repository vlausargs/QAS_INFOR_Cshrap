//PROJECT NAME: Data
//CLASS NAME: IGetReplProperty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetReplProperty
	{
		string GetReplPropertyFn(
			string Property,
			string Parsing);
	}
}

