//PROJECT NAME: Finance
//CLASS NAME: IReplaceUnitCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IReplaceUnitCodes
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
		string Infobar) ReplaceUnitCodesSp(
			string BegAcct,
			string EndAcct,
			int? UnitNumber,
			string OldUnitCode,
			string NewUnitCode,
			string Infobar);
	}
}

