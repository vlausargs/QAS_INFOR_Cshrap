//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXPOSGetKeys.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXPOSGetKeys
	{
		(int? ReturnCode,
			string oHdrRef1,
			string oHdrRef2,
			int? oHdrRef3,
			string oLineRef1,
			int? oLineRef2,
			int? oLineRef3,
			string Infobar) SSSVTXPOSGetKeysSp(
			string pRefType,
			Guid? pHdrPtr,
			string pLineRefType,
			Guid? pLinePtr,
			string pLineType,
			string oHdrRef1,
			string oHdrRef2,
			int? oHdrRef3,
			string oLineRef1,
			int? oLineRef2,
			int? oLineRef3,
			string Infobar);
	}
}

