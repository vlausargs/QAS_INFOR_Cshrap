//PROJECT NAME: Config
//CLASS NAME: ICopyRoutingBOMPredisplay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICopyRoutingBOMPredisplay
	{
		(int? ReturnCode, string Infobar) CopyRoutingBOMPredisplaySp(string pOldConfigID,
		string pNewCoNum,
		int? pNewCoLine,
		int? pNewCoRelease,
		string pNewJob,
		int? pNewSuffix,
		string pNewItem,
		string pRecType,
		string pKey1,
		string pKey2,
		string pKey3,
		string pNewConfigGid,
		string pConfigurator,
		string Infobar);
	}
}

