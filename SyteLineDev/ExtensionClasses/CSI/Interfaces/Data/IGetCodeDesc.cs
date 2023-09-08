//PROJECT NAME: Data
//CLASS NAME: IGetCodeDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
	public interface IGetCodeDesc
	{
		string GetCodeDescFn(string PClass,
		string PCharCode = null,
		int? PIntCode = null);
	}
}

