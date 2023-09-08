//PROJECT NAME: Data
//CLASS NAME: IItemCanLotSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemCanLotSerial
	{
		int? ItemCanLotSerialFn(
			string Item);
	}
}

