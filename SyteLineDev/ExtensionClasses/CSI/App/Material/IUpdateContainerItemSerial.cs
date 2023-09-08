//PROJECT NAME: Material
//CLASS NAME: IUpdateContainerItemSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateContainerItemSerial
	{
		(int? ReturnCode, string Infobar) UpdateContainerItemSerialSp(string PItem,
		string PLot,
		string PContainerNum,
		Guid? PSessionId,
		string Infobar);
	}
}

