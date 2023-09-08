//PROJECT NAME: Data
//CLASS NAME: IJP_CutoffDateForTermsCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJP_CutoffDateForTermsCode
	{
		DateTime? JP_CutoffDateForTermsCodeFn(
			DateTime? Date,
			string pTermsCode);
	}
}

