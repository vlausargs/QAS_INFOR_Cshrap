//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigSearchLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigSearchLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSConfigSearchLoadSp(int? Current,
		string SerNum,
		string Item,
		string CustNum,
		string Search,
		int? UnitSer,
		int? UnitItem,
		int? UnitCustItem,
		int? UnitDesc,
		int? CompSer,
		int? CompItem,
		int? CompCustItem,
		int? CompDesc);
	}
}

