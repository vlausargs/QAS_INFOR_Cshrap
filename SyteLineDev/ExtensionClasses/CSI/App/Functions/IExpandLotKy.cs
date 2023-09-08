//PROJECT NAME: Data
//CLASS NAME: IExpandLotKy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IExpandLotKy
	{
		string ExpandLotKyFn(
			string Key,
			string Site,
			string Prefix);
	}
}

