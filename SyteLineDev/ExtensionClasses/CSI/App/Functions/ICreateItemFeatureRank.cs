//PROJECT NAME: Data
//CLASS NAME: ICreateItemFeatureRank.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateItemFeatureRank
	{
		(int? ReturnCode,
			string Infobar) CreateItemFeatureRankSp(
			string Item,
			int? FeatrankRank,
			string FeatrankFeature,
			int? FeatrankOperNum,
			string Infobar);
	}
}

