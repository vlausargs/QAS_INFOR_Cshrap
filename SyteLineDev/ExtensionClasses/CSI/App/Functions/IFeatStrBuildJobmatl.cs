//PROJECT NAME: Data
//CLASS NAME: IFeatStrBuildJobmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFeatStrBuildJobmatl
	{
		(int? ReturnCode,
			string Infobar) FeatStrBuildJobmatlSp(
			string FeatStr,
			string Item,
			string CoNum = null,
			int? CoLine = null,
			string Infobar = null,
			int? ExpandPhantom = 0,
			decimal? QtyMultiplier = 1M,
			string Site = null);
	}
}

