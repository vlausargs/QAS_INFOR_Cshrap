//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriverAsnCPPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriverAsnCPPS
	{
		(int? ReturnCode,
			string Infobar) EdiOutObDriverAsnCPPSSp(
			decimal? PShipmentID,
			string Infobar);
	}
}

