//PROJECT NAME: Data
//CLASS NAME: IExpandKyByTypeSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IExpandKyByTypeSite
	{
		string ExpandKyByTypeSiteFn(
			string DataType,
			string Key,
			string Site);
	}
}

