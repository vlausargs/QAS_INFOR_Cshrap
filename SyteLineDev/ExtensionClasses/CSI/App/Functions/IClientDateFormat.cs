//PROJECT NAME: Data
//CLASS NAME: IClientDateFormat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IClientDateFormat
	{
		string ClientDateFormatFn(
			DateTime? Date);
	}
}

