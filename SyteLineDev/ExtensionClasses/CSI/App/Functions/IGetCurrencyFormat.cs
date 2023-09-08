//PROJECT NAME: Data
//CLASS NAME: IGetCurrencyFormat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCurrencyFormat
	{
		(int? ReturnCode,
			string AmtFormat,
			string AmtTotFormat,
			string CstPrcFormat,
			string Infobar) GetCurrencyFormatSp(
			string AmtFormat,
			string AmtTotFormat,
			string CstPrcFormat,
			string Infobar);
	}
}

