//PROJECT NAME: Material
//CLASS NAME: ICopyCostingAnalysisAlternative.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICopyCostingAnalysisAlternative
	{
		(int? ReturnCode,
		string Infobar) CopyCostingAnalysisAlternativeSp(
			string CostingAlt,
			string CostingAltDescription,
			string BOMType,
			string Whse,
			string CostingAltFrom,
			int? CopyRouting,
			string PMTCode,
			string ABCCode,
			string CostMethod,
			string MatlType,
			string ProductCodeStarting,
			string ProductCodeEnding,
			string ItemStarting,
			string ItemEnding,
			string Infobar);
	}
}

