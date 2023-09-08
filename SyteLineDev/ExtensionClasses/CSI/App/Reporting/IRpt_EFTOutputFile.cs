//PROJECT NAME: Reporting
//CLASS NAME: IRpt_EFTOutputFile.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_EFTOutputFile
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EFTOutputFileSp(string PSessionIDChar,
		string PSortNameNum = null,
		string EFTFormat = null,
		string EFTBankCode = null,
		string pSite = null);
	}
}

