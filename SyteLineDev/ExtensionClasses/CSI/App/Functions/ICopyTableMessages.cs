//PROJECT NAME: Data
//CLASS NAME: ICopyTableMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyTableMessages
	{
		int? CopyTableMessagesSp(
			string TableName,
			string NewAltNo);
	}
}

