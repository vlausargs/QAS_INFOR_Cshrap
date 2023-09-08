//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriverAckC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriverAckC
	{
		(int? ReturnCode,
			string Infobar) EdiOutObDriverAckCSp(
			string PCoNum,
			string Infobar);
	}
}

