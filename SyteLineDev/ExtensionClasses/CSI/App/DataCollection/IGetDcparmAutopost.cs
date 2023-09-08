//PROJECT NAME: DataCollection
//CLASS NAME: IGetDcparmAutopost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IGetDcparmAutopost
	{
		(int? ReturnCode, int? AutoPostFlag,
		string Infobar) GetDcparmAutopostSp(string AutoPostFieldName,
		int? AutoPostFlag,
		string Infobar);
	}
}

