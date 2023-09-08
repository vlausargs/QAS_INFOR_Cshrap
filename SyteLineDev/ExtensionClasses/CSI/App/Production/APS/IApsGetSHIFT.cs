//PROJECT NAME: Production
//CLASS NAME: IApsGetSHIFT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetSHIFT
	{
		(int? ReturnCode, string DESCR,
		string Infobar) ApsGetSHIFTSp(int? AltNo,
		string SHIFTID,
		string DESCR,
		string Infobar);
	}
}

