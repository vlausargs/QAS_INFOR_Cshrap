//PROJECT NAME: Data
//CLASS NAME: ISetValueAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetValueAddress
	{
		(int? ReturnCode,
			string PText) SetValueAddressSp(
			string PText,
			int? PIndex,
			string PValue);
	}
}

