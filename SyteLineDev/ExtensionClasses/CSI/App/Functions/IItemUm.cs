//PROJECT NAME: Data
//CLASS NAME: IItemUm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemUm
	{
		(int? ReturnCode,
			string PUm,
			decimal? PUomConvFactor,
			string Infobar) ItemUmSp(
			string PItem,
			string PUm,
			decimal? PUomConvFactor,
			string Infobar);
	}
}

