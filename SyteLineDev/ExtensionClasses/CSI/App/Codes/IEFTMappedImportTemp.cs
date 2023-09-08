//PROJECT NAME: Codes
//CLASS NAME: IEFTMappedImportTemp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IEFTMappedImportTemp
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) EFTMappedImportTempSp(string FileName,
		string MapId,
		string ReturnType,
		decimal? ImportSequence,
		string InfoBar);
	}
}

