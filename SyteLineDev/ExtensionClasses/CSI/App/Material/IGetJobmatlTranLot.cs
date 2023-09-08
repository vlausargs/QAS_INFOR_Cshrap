//PROJECT NAME: Material
//CLASS NAME: IGetJobmatlTranLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetJobmatlTranLot
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetJobmatlTranLotSp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string Whse,
		string Item,
		string Loc,
		string FilterString = null);
	}
}

