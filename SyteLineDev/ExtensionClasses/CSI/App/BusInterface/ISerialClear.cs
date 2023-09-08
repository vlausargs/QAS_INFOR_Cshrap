//PROJECT NAME: BusInterface
//CLASS NAME: ISerialClear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ISerialClear
	{
		(int? ReturnCode, string Infobar) SerialClearSp(string RefStr = null,
		string Infobar = null);
	}
}

