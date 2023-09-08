//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConfigRcrRemoveSubunit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigRcrRemoveSubunit
	{
		(int? ReturnCode,
			string Infobar) SSSFSUnitConfigRcrRemoveSubunitSp(
			int? iCompID,
			DateTime? iRemoveDate,
			string iReason,
			int? iParentID,
			string Infobar,
			string iSroNum = null,
			int? iSroLine = null,
			int? iSroOper = null,
			int? iTransNum = null);
	}
}

