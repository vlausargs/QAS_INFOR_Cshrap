//PROJECT NAME: Data
//CLASS NAME: IMaskBank.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaskBank
	{
		string MaskBankFn(
			string PBankAcct);
	}
}

