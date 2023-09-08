//PROJECT NAME: Data
//CLASS NAME: IMaskSSN.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaskSSN
	{
		string MaskSSNFn(
			string PSsn);
	}
}

