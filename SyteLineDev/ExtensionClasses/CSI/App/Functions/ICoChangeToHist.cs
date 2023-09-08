//PROJECT NAME: Data
//CLASS NAME: ICoChangeToHist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoChangeToHist
	{
		(int? ReturnCode,
			string Infobar) CoChangeToHistSp(
			string PCoNum,
			string POrigSite,
			string Infobar,
			int? RepFromTrigger = 0);
	}
}

