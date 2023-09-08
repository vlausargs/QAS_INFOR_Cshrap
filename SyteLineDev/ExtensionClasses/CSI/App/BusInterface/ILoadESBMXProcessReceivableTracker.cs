//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBMXProcessReceivableTracker.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBMXProcessReceivableTracker
	{
		(int? ReturnCode,
			string Infobar) LoadESBMXProcessReceivableTrackerSp(
			string ActionExpression = null,
			string ProcessArCheckNum = null,
			string UUID = null,
			string Status = null,
			string ErrMessage = null,
			string Filename = null,
			string Infobar = null);
	}
}

