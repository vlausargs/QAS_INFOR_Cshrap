//PROJECT NAME: Data
//CLASS NAME: IChkXrefAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChkXrefAll
	{
		(int? ReturnCode,
			string Infobar) ChkXrefAllSp(
			string CoNum = null,
			int? CoLine = null,
			int? CoRelease = null,
			string OldRefType = null,
			string NewRefType = null,
			string NewRefNum = null,
			int? NewRefLineSuf = null,
			int? NewRefRel = null,
			string NewItem = null,
			string DestinationType = null,
			string ShipSite = null,
			string Infobar = null);
	}
}

