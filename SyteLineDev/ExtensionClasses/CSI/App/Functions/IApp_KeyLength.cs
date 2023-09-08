//PROJECT NAME: Data
//CLASS NAME: IApp_KeyLength.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_KeyLength
	{
		int? App_KeyLengthFn(
			string DataType);
	}
}

