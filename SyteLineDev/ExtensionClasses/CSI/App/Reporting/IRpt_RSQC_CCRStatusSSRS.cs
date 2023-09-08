//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CCRStatusSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CCRStatusSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CCRStatusSSRSSp(string CompanyName = null,
		string ProductLine = null,
		string begReasonCode = null,
		string endReasonCode = null,
		string begccr = null,
		string endccr = null,
		int? Openccr = null,
		int? closeccr = null,
		int? displayheader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

