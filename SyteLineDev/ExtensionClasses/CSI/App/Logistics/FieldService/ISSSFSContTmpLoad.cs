//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContTmpLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContTmpLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSContTmpLoadSp(string SerNum,
		string Item,
		string CustNum,
		DateTime? TestDate,
		int? InclBad,
		string UsrNum = null,
		int? CustSeq = null,
		int? UsrSeq = null,
		string Mode = null,
		string FilterString = null);
	}
}

