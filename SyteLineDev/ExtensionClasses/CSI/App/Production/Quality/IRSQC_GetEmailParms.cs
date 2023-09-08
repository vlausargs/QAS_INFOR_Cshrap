//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetEmailParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetEmailParms
	{
		(int? ReturnCode, string CarEMail,
		string MrrEMail,
		string CcrEMail,
		string VrmaEMail) RSQC_GetEmailParmsSp(string CarEMail,
		string MrrEMail,
		string CcrEMail,
		string VrmaEMail);
	}
}

