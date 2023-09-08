//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXGetRealRefType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXGetRealRefType
	{
		string SSSVTXGetRealRefTypeFn(
			string RefType);
	}
}

