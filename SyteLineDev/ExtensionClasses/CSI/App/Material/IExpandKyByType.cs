//PROJECT NAME: Material
//CLASS NAME: IExpandKyByType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IExpandKyByType
	{
		(int? ReturnCode, string Result) ExpandKyByTypeSp(string DataType,
		string Key,
		string Site = null,
		string Result = null);

		string ExpandKyByTypeFn(string DataType,
		string Key);
	}
}

