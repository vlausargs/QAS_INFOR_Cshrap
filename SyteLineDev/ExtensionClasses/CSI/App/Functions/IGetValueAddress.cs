//PROJECT NAME: Data
//CLASS NAME: IGetValueAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetValueAddress
	{
		(int? ReturnCode,
			string PValue) GetValueAddressSp(
			string PText,
			int? PIndex,
			string PValue);
	}
}

