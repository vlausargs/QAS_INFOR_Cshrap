//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSWarrAct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSWarrAct
	{
		int? SSSFSWarrActFn(
			string iCompID,
			string iWarrCode = null,
			DateTime? iDate = null,
			int? iMeter = null);
	}
}

