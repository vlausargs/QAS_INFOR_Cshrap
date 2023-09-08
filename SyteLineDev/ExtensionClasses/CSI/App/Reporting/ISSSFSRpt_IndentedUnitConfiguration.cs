//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_IndentedUnitConfiguration.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_IndentedUnitConfiguration
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_IndentedUnitConfigurationSp(string StartingSerNum,
		string EndingSerNum,
		string StartingItem,
		string EndingItem,
		int? IncludeWarranty,
		int? tLevel,
		DateTime? ConfigDate,
		int? tpage,
		string pSite = null);
	}
}

