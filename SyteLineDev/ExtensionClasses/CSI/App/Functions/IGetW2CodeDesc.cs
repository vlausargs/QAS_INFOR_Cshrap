//PROJECT NAME: Data
//CLASS NAME: IGetW2CodeDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetW2CodeDesc
	{
		string GetW2CodeDescFn(
			string pW2Code);
	}
}

