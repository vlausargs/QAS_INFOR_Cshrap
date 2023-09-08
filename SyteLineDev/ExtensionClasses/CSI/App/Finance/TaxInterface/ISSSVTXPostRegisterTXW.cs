//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXPostRegisterTXW.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXPostRegisterTXW
	{
		(int? ReturnCode,
			string Infobar) SSSVTXPostRegisterTXWSp(
			string FormCaption,
			int? BGTaskID,
			string Infobar);
	}
}

