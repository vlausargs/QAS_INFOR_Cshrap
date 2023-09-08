//PROJECT NAME: Data
//CLASS NAME: IMdayCal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMdayCal
	{
		(int? ReturnCode,
			DateTime? MdayDate,
			string Infobar) MdayCalSp(
			int? RunCalcHorizon = 1,
			DateTime? MdayDate = null,
			string Infobar = null);
	}
}

