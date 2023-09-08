//PROJECT NAME: Reporting
//CLASS NAME: IRpt_UnitCodeWhereUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_UnitCodeWhereUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_UnitCodeWhereUsedSp(string UnitCode1Starting = null,
		string UnitCode1Ending = null,
		string UnitCode2Starting = null,
		string UnitCode2Ending = null,
		string UnitCode3Starting = null,
		string UnitCode3Ending = null,
		string UnitCode4Starting = null,
		string UnitCode4Ending = null,
		int? DisplayHeader = null,
		string MessageLanguage = null,
		string pSite = null,
		string BGUser = null);
	}
}

