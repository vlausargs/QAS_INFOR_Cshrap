//PROJECT NAME: Data
//CLASS NAME: IGetGMTDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetGMTDate
	{
		(int? ReturnCode,
			string Infobar,
			DateTime? Result1,
			DateTime? Result2,
			DateTime? Result3,
			DateTime? Result4,
			DateTime? Result5,
			DateTime? Result6,
			DateTime? Result7,
			DateTime? Result8,
			DateTime? Result9,
			DateTime? Result10) GetGMTDateSp(
			string Infobar,
			DateTime? Date1,
			DateTime? Result1,
			DateTime? Date2 = null,
			DateTime? Result2 = null,
			DateTime? Date3 = null,
			DateTime? Result3 = null,
			DateTime? Date4 = null,
			DateTime? Result4 = null,
			DateTime? Date5 = null,
			DateTime? Result5 = null,
			DateTime? Date6 = null,
			DateTime? Result6 = null,
			DateTime? Date7 = null,
			DateTime? Result7 = null,
			DateTime? Date8 = null,
			DateTime? Result8 = null,
			DateTime? Date9 = null,
			DateTime? Result9 = null,
			DateTime? Date10 = null,
			DateTime? Result10 = null);

		DateTime? GetGMTDateFn(
			DateTime? Date);
	}
}

