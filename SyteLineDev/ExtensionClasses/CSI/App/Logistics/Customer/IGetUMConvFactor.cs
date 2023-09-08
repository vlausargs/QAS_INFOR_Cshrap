//PROJECT NAME: Logistics
//CLASS NAME: IGetUMConvFactor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetUMConvFactor
	{
		(int? ReturnCode,
			decimal? UomConvConvFactor,
			string Infobar) GetUMConvFactorSp(
			string FromUM,
			string ToUM,
			decimal? UomConvConvFactor,
			string Infobar);
	}
}

