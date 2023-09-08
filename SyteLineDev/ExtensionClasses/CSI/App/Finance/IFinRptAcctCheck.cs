//PROJECT NAME: Finance
//CLASS NAME: IFinRptAcctCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptAcctCheck
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FinRptAcctCheckSp(string ReportId,
		int? StartSeq,
		int? EndSeq,
		string StartAcct,
		string EndAcct,
		string AccountTypes,
		string FilterString = null);
	}
}

