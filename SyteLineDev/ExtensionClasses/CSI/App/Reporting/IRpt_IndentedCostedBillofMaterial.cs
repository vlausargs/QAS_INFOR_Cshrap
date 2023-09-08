//PROJECT NAME: Reporting
//CLASS NAME: IRpt_IndentedCostedBillofMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_IndentedCostedBillofMaterial
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_IndentedCostedBillofMaterialSp(
			string ItemStarting = null,
			string ItemEnding = null,
			string ProCodeStarting = null,
			string ProCodeEnding = null,
			string AlternateIDStarting = null,
			string AlternateIDEnding = null,
			string MaterialType = null,
			string Source = null,
			string Stocked = null,
			string ABCCode = null,
			DateTime? EffDate = null,
			string PrBetweenLevel0 = null,
			int? PrLevelZero = null,
			int? DisplayHeader = null,
			int? PrintAlternate = null,
			int? EffDateOffSet = null,
			string pSite = null);
	}
}

