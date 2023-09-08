//PROJECT NAME: Data
//CLASS NAME: IConvertSuffixName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertSuffixName
	{
		string ConvertSuffixNameFn(
			string Name,
			string FName,
			string MI,
			string LName);
	}
}

