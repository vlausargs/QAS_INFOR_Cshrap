//PROJECT NAME: Data
//CLASS NAME: IGetSuffixName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSuffixName
	{
		string GetSuffixNameFn(
			string Name,
			string FName,
			string MI,
			string LName);
	}
}

