//PROJECT NAME: Codes
//CLASS NAME: IUpdateEuroParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IUpdateEuroParms
	{
		(int? ReturnCode, string Infobar) UpdateEuroParmsSp(int? CurrParmsParmKey,
		string EuroParmsCurrCode,
		string Infobar);
	}
}

