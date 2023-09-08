//PROJECT NAME: Production
//CLASS NAME: IEcnTrack.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IEcnTrack
	{
		(int? ReturnCode, int? PTrackEcn,
		string Infobar) EcnTrackSp(string PJob,
		int? PSuffix,
		string PType,
		int? PTrackEcn,
		string Infobar);
	}
}

