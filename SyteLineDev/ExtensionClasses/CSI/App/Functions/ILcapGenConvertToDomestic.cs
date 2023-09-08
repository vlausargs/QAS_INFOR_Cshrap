//PROJECT NAME: Data
//CLASS NAME: ILcapGenConvertToDomestic.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILcapGenConvertToDomestic
	{
		(int? ReturnCode,
			decimal? pAmount,
			string Infobar) LcapGenConvertToDomesticSp(
			string pForeignVendNum,
			string pDomesticVendNum,
			decimal? pRate,
			decimal? pAmount,
			string Infobar,
			string ParmsSite = null,
			string CurrparmsCurrCode = null);
	}
}

