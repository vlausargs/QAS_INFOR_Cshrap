//PROJECT NAME: Production
//CLASS NAME: ILOOKUPSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ILOOKUPSave
	{
		int? LOOKUPSaveSp(int? InsertFlag,
		int? AltNo,
		string TABID,
		string INDEX1,
		string INDEX2,
		decimal? VAL);
	}
}

