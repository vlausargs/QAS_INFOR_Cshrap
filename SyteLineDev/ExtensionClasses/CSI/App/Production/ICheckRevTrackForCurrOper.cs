//PROJECT NAME: Production
//CLASS NAME: ICheckRevTrackForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckRevTrackForCurrOper
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string MatlType,
		int? EcnTrack,
		string Infobar) CheckRevTrackForCurrOperSp(string Item,
		string Job,
		int? Suffix,
		string MatlType,
		int? EcnTrack,
		string Infobar,
		string JobType);
	}
}

