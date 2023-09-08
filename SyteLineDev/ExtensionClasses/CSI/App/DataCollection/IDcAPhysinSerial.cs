//PROJECT NAME: DataCollection
//CLASS NAME: IDcAPhysinSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAPhysinSerial
	{
		(int? ReturnCode, string Infobar) DcAPhysinSerialSp(Guid? PPhyinvRowPointer,
		string PSerNum,
		string Infobar);
	}
}

