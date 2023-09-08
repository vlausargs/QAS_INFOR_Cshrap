//PROJECT NAME: Production
//CLASS NAME: IApsRGRPDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsRGRPDel
	{
		int? ApsRGRPDelSp(int? AltNo,
		string RgID);
	}
}

