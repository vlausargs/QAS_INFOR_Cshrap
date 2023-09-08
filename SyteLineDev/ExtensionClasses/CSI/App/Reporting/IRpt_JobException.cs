//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobException.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobException
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobExceptionSp(string StartJob = null,
		string EndJob = null,
		int? SSuffix = null,
		int? ESuffix = null,
		string Status = null,
		decimal? TolFactor = null,
		int? ShowDetail = null,
		string DispJobTol = null,
		string StartItem = null,
		string EndItem = null,
		string SCustNum = null,
		string ECustNum = null,
		string StartProdMix = null,
		string EndProdMix = null,
		string OrdType = null,
		string SOrdNum = null,
		string EOrdNum = null,
		DateTime? SLstTrxDate = null,
		DateTime? ELstTrxDate = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? SLstTrxDateOffSET = null,
		int? ELstTrxDateOffSET = null,
		int? SJobDateOffSET = null,
		int? EJobDateOffSET = null,
		int? DisplayHeader = null,
		string pSite = null,
		string BGUser = null);
	}
}

