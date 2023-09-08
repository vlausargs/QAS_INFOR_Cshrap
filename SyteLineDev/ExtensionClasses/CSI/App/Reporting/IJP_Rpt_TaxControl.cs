//PROJECT NAME: Reporting
//CLASS NAME: IJP_Rpt_TaxControl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IJP_Rpt_TaxControl
	{
		(ICollectionLoadResponse Data, int? ReturnCode) JP_Rpt_TaxControlSp(int? DisplayHeader = null,
		string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string Style = null,
		string pSite = null);
	}
}

