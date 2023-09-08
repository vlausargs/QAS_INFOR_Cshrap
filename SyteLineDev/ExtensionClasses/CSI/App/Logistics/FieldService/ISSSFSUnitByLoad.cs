//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitByLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitByLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSUnitByLoadSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string Item,
		string Unit);
	}
}

