//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SingleLevelCurrentBillOfMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SingleLevelCurrentBillOfMaterial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SingleLevelCurrentBillOfMaterialSp(string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string AlternateIDStarting = null,
		string AlternateIDEnding = null,
		string MaterialType = null,
		string Source = null,
		string Shocked = null,
		string ABCCode = null,
		int? ShowCost = null,
		int? DisplayReferenceFields = null,
		int? PageBetweenItems = null,
		int? PrintAlternate = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

