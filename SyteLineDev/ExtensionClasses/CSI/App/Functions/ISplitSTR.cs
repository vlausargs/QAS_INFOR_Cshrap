//PROJECT NAME: Data
//CLASS NAME: ISplitSTR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISplitSTR
	{
		ICollectionLoadResponse SplitSTRFn(
			string s,
			string split);
	}
}

