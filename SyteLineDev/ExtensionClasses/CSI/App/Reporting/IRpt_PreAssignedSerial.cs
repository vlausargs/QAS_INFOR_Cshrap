//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PreAssignedSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PreAssignedSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PreAssignedSerialSp(string Item = null,
		string RefType = null,
		string RefNum = null,
		int? RefLineSuf = null,
		int? RefRelease = null,
		string pSite = null);
	}
}

