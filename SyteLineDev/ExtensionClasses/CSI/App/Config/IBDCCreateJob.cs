//PROJECT NAME: Config
//CLASS NAME: IBDCCreateJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface IBDCCreateJob
	{
		(int? ReturnCode, string Infobar) BDCCreateJobSp(string sConfigID,
		string sOrderType,
		string Infobar);
	}
}

