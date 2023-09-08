//PROJECT NAME: Codes
//CLASS NAME: IGenerateEFTMappedImportView.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGenerateEFTMappedImportView
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) GenerateEFTMappedImportViewSp(string FileName,
		string MapId,
		string ReturnType,
		decimal? ImportSequence,
		string InfoBar);

		ICollectionLoadResponse GenerateEFTMappedImportViewFn(
			string FileName,
			string MapID,
			string ReturnFormat);
	}
}

