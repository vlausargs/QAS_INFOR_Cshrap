//PROJECT NAME: Data
//CLASS NAME: IConvertTimeFromHTMLtoHours.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertTimeFromHTMLtoHours
	{
		decimal? ConvertTimeFromHTMLtoHoursFn(
			string HTMLTime);
	}
}

