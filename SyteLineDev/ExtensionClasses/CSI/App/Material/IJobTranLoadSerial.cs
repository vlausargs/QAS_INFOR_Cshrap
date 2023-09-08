//PROJECT NAME: Material
//CLASS NAME: IJobTranLoadSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IJobTranLoadSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) JobTranLoadSerialSp(decimal? TransNum,
		string Job,
		int? Suffix,
		decimal? QtyMoved,
		string MoveToLocation,
		string FilterString = null);
	}
}

