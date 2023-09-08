//PROJECT NAME: Material
//CLASS NAME: ISerialNumValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ISerialNumValidation
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) SerialNumValidationSp(string SerNum,
		string Item,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

