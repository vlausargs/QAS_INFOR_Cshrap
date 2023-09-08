//PROJECT NAME: Data
//CLASS NAME: IFndDistProdCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFndDistProdCode
	{
		Guid? FndDistProdCodeFn(
			string ProductCode,
			string Whse);
	}
}

