//PROJECT NAME: Data
//CLASS NAME: IFTInsertSRO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTInsertSRO
	{
		(int? ReturnCode,
			string Infobar) FTInsertSROSp(
			Guid? SessionID,
			string Infobar);
	}
}

