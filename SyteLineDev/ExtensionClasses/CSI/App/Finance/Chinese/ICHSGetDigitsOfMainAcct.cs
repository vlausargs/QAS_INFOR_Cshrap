//PROJECT NAME: Finance
//CLASS NAME: ICHSGetDigitsOfMainAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetDigitsOfMainAcct
	{
		(int? ReturnCode,
		int? DigitsOfMainAcct) CHSGetDigitsOfMainAcctSp(
			int? DigitsOfMainAcct);
	}
}

