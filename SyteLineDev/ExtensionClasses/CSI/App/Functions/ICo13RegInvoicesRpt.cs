//PROJECT NAME: Data
//CLASS NAME: ICo13RegInvoicesRpt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICo13RegInvoicesRpt
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Co13RegInvoicesRptSp(
			string SortBy = "O");
	}
}

