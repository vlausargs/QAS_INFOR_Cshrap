//PROJECT NAME: DataCollection
//CLASS NAME: IGetDcparmAutopostEscFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IGetDcparmAutopostEscFlag
	{
		(int? ReturnCode, int? AutoPostFlag,
		string EscFlag,
		string Infobar) GetDcparmAutopostEscFlagSp(string AutoPostFieldName,
		int? AutoPostFlag,
		string EscFlag,
		string Infobar);
	}
}

