//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConfigRcrRemove.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigRcrRemove
	{
		(int? ReturnCode,
			string Infobar) SSSFSUnitConfigRcrRemoveSp(
			int? iCompID,
			DateTime? iRemoveDate,
			string iReason,
			string Infobar,
			string iSroNum = null,
			int? iSroLine = null,
			int? iSroOper = null,
			int? iTransNum = null);
	}
}

