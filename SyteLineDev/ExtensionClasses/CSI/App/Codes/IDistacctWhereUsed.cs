//PROJECT NAME: Codes
//CLASS NAME: IDistacctWhereUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IDistacctWhereUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DistacctWhereUsedSp(string ProductCode,
		string Whse,
		string FilterString);
	}
}

