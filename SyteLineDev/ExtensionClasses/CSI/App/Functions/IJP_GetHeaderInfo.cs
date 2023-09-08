//PROJECT NAME: Data
//CLASS NAME: IJP_GetHeaderInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJP_GetHeaderInfo
	{
		(int? ReturnCode,
			string CustNum,
			int? CustSeq,
			string ConsumptionTaxHeaderLineMethod,
			string ConsumptionTaxRoundMethod) JP_GetHeaderInfoSp(
			string RefType = null,
			Guid? RowPointer = null,
			string CustNum = null,
			int? CustSeq = null,
			string ConsumptionTaxHeaderLineMethod = null,
			string ConsumptionTaxRoundMethod = null);
	}
}

