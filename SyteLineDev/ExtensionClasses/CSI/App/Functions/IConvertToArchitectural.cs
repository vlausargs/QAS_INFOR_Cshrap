//PROJECT NAME: Data
//CLASS NAME: IConvertToArchitectural.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertToArchitectural
	{
		string ConvertToArchitecturalFn(
			string Value);
	}
}

