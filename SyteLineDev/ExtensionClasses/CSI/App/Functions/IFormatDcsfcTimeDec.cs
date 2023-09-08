//PROJECT NAME: Data
//CLASS NAME: IFormatDcsfcTimeDecSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatDcsfcTimeDec
	{
		decimal? FormatDcsfcTimeDecSp(
			int? TimeSec);
	}
}

