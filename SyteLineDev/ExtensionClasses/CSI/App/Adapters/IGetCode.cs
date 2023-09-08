//PROJECT NAME: Adapters
//CLASS NAME: IGetCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Adapters
{
	public interface IGetCode
	{
		(int? ReturnCode, string PDesc,
		string PAltDesc,
		string PLocCode,
		string PBaseCode) GetCodeSp(string PClass,
		string PCode,
		string PDesc = null,
		string PAltDesc = null,
		string PLocCode = null,
		string PBaseCode = null);
	}
}

