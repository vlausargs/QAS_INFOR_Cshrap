//PROJECT NAME: Material
//CLASS NAME: IUpdatePreassignedSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdatePreassignedSerial
	{
		(int? ReturnCode, string Infobar) UpdatePreassignedSerialSp(int? Select,
		string SerNum,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		string Infobar);
	}
}

