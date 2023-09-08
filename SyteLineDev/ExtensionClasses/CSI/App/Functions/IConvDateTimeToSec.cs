//PROJECT NAME: Data
//CLASS NAME: IConvDateTimeToSec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvDateTimeToSec
	{
		int? ConvDateTimeToSecFn(
			DateTime? Date);
	}
}

