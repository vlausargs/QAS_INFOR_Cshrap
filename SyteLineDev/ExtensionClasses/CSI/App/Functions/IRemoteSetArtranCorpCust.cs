//PROJECT NAME: Data
//CLASS NAME: IRemoteSetArtranCorpCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteSetArtranCorpCust
	{
		(int? ReturnCode,
			string Infobar) RemoteSetArtranCorpCustSp(
			string CustNum,
			string CorpCust,
			string Infobar);
	}
}

