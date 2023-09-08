//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXFSPGetKeys.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXFSPGetKeys
	{
		(int? ReturnCode,
			string oHdrRef1,
			string oHdrRef2,
			int? oHdrRef3,
			string oLineRef1,
			int? oLineRef2,
			int? oLineRef3,
			string Infobar) SSSVTXFSPGetKeysSp(
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

