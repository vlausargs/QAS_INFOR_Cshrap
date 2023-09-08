//PROJECT NAME: Reporting
//CLASS NAME: IWBCanJobScrapValGetRecs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.CriticalNumber
{
	public interface IWBCanJobScrapValGetRecs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) WBCanJobScrapValGetRecsSp(
			string Job,
			int? Suffix,
			int? OperNum,
			string Shift,
			string Wc,
			string ProductCode,
			string Item);
	}
}

