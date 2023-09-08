//PROJECT NAME: Data
//CLASS NAME: ISLocDef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISLocDef
	{
		(int? ReturnCode,
			string Lot,
			string Loc,
			string InfoBar,
			string ImportDocId) SLocDefSp(
			string Item,
			string Whse,
			string Lot,
			string Loc,
			string InfoBar,
			string ExportType,
			string ImportDocId);
	}
}

