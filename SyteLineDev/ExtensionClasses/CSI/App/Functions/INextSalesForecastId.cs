//PROJECT NAME: Data
//CLASS NAME: INextSalesForecastId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextSalesForecastId
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextSalesForecastIdSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

