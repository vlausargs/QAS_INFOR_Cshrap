//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXGetErrorDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXGetErrorDesc
	{
		string SSSVTXGetErrorDescFn(
			string pClass,
			int? pCode);
	}
}

