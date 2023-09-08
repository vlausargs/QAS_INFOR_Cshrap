//PROJECT NAME: DataCollection
//CLASS NAME: IGetInvparmAutoGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IGetInvparmAutoGen
	{
		(int? ReturnCode, int? AutoGenFlag,
		string Infobar) GetInvparmAutoGenSp(string AutoGenFieldName,
		int? AutoGenFlag,
		string Infobar);
	}
}

