//PROJECT NAME: Data
//CLASS NAME: IGainLossValidateAccts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLossValidateAccts
	{
		(int? ReturnCode,
			string rInfobar) GainLossValidateAcctsSp(
			string pAcctType,
			int? pRelGl,
			DateTime? pTTransDate,
			string pSCurrCode,
			string pECurrCode,
			string rInfobar = null);
	}
}

