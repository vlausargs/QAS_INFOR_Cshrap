//PROJECT NAME: Finance
//CLASS NAME: ICHSDetailLeftOverGenData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSDetailLeftOverGenData
	{
		int? CHSDetailLeftOverGenDataSP(
			string Text,
			DateTime? sdate,
			DateTime? edate);
	}
}

