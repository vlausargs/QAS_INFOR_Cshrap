//PROJECT NAME: Codes
//CLASS NAME: IEFTMapCreateDataView.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IEFTMapCreateDataView
	{
		(int? ReturnCode, string InfoBar) EFTMapCreateDataViewSp(string MapId,
		string InfoBar);
	}
}

