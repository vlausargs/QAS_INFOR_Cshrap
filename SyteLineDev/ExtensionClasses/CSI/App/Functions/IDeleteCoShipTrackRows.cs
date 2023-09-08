//PROJECT NAME: Data
//CLASS NAME: IDeleteCoShipTrackRows.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteCoShipTrackRows
	{
		(int? ReturnCode,
			string Infobar) DeleteCoShipTrackRowsSp(
			string Infobar);
	}
}

