//PROJECT NAME: Finance
//CLASS NAME: IMXReconDateValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXReconDateValidate
	{
		(int? ReturnCode,
			string Infobar) MXReconDateValidateSp(
			DateTime? TransDate,
			DateTime? ReconDate,
			string Infobar);
	}
}

