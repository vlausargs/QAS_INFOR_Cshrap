//PROJECT NAME: Data
//CLASS NAME: IFmtTimeHrsSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFmtTimeHrs
	{
		decimal? FmtTimeHrsSp(
			int? TimeSec);
	}
}

