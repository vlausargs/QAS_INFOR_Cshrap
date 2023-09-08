//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAutoSROGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAutoSROGen
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSAutoSROGenSp(int? iCreateSROs,
		DateTime? iThroughDate,
		string iStartSerNum,
		string iEndSerNum,
		string iStartSroType,
		string iEndSroType,
		string iStartDept,
		string iEndDept,
		string iStartWc,
		string iEndWc,
		int? iKeepOperNums,
		int? iDateOffset,
		string pSite = null);
	}
}

