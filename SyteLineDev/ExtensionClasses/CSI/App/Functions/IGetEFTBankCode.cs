//PROJECT NAME: Data
//CLASS NAME: IGetEFTBankCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEFTBankCode
	{
		string GetEFTBankCodeFn(
			string FileName);
	}
}

