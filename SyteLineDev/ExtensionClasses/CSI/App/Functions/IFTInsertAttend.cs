//PROJECT NAME: Data
//CLASS NAME: IFTInsertAttend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTInsertAttend
	{
		(int? ReturnCode,
			string Infobar) FTInsertAttendSp(
			Guid? SessionID,
			string Infobar);
	}
}

