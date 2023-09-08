//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriver.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriver
	{
		(int? ReturnCode,
			int? PFlag,
			string Infobar) EdiOutObDriverSp(
			string PTranType,
			string PCustNum,
			int? PCustSeq,
			string PInvNum,
			string PCoNum,
			string PBolNum,
			int? PFlag,
			string Infobar);
	}
}

