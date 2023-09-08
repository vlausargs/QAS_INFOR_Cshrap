//PROJECT NAME: Codes
//CLASS NAME: IClearTrackRows.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IClearTrackRows
	{
		(int? ReturnCode, string Infobar) ClearTrackRowsSp(
			Guid? SessionID,
			string TrackedOperType,
			string Infobar = null);
	}
}

