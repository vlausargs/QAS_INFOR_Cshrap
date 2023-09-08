//PROJECT NAME: Finance
//CLASS NAME: IFRCLM_FecExport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFRCLM_FecExport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FRCLM_FecExportSp(int? PYear,
		int? PPeriod,
		string PSAcct,
		string PEAcct);
	}
}

