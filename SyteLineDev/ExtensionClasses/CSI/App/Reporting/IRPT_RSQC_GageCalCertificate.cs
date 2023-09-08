//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_GageCalCertificate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_GageCalCertificate
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GageCalCertificateSp(
			string BegGage = null,
			string EndGage = null,
			int? BegTransNum = null,
			int? EndTransNum = null,
			DateTime? BegCalDate = null,
			DateTime? EndCalDate = null,
			int? DisplayHeader = null,
			string psite = null);
	}
}

