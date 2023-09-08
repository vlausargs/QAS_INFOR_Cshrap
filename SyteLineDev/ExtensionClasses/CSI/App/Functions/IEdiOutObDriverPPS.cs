//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriverPPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriverPPS
	{
		(int? ReturnCode,
			int? PFlag,
			string Infobar) EdiOutObDriverPPSSp(
			string PTranType,
			string PCustNum,
			int? PCustSeq,
			string PInvNum,
			string PCoNum,
			decimal? PBolNum,
			int? PFlag,
			string Infobar);
	}
}

