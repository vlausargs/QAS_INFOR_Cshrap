//PROJECT NAME: Finance
//CLASS NAME: ICHSDetailLeftOverGenAcctUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSDetailLeftOverGenAcctUnit
	{
		int? CHSDetailLeftOverGenAcctUnitSP(
			DateTime? PEndDate);
	}
}

