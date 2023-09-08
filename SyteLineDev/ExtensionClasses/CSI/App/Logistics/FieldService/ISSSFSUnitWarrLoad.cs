//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitWarrLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitWarrLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSUnitWarrLoadSp(string CustNum,
		string UsrNum,
		DateTime? IncDate = null,
		decimal? MeterAmt = null,
		string SerNum = null,
		string Item = null,
		int? CustSeq = null,
		int? UsrSeq = null,
		string Mode = null,
		string FilterString = null);
	}
}

