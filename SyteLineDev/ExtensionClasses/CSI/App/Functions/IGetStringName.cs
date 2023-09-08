//PROJECT NAME: Data
//CLASS NAME: IGetStringName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetStringName
	{
		string GetStringNameFn(
			string ObjectName,
			string MessageText,
			string Name,
			string String);
	}
}

