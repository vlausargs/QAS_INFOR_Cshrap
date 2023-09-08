//PROJECT NAME: Data
//CLASS NAME: IMaskBankTransit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaskBankTransit
	{
		string MaskBankTransitFn(
			int? PTransit);
	}
}

