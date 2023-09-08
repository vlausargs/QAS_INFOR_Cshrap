//PROJECT NAME: Production
//CLASS NAME: IMO_ValAlternateAsk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMO_ValAlternateAsk
	{
		(int? ReturnCode, string AlternateDescription,
		int? JobSuffix,
		string PromptAddMsg,
		string PromptAddButtons,
		string Infobar,
		int? OperNum) MO_ValAlternateAskSp(string JobItem,
		string AlternateID,
		string AlternateDescription,
		int? JobSuffix,
		string PromptAddMsg,
		string PromptAddButtons,
		string Infobar,
		int? OperNum = null);
	}
}

