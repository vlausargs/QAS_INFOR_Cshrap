//PROJECT NAME: Data
//CLASS NAME: IMaskAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaskAmount
	{
		string MaskAmountFn(
			string Value,
			int? number_of_implied_decimals);
	}
}

