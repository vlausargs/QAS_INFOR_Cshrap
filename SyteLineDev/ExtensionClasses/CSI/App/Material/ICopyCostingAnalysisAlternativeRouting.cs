//PROJECT NAME: Material
//CLASS NAME: ICopyCostingAnalysisAlternativeRouting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICopyCostingAnalysisAlternativeRouting
	{
		(int? ReturnCode, string Infobar) CopyCostingAnalysisAlternativeRoutingSp(string CostingAlt,
		string Item,
		string CostingAltFrom = null,
		string Infobar = null);
	}
}

