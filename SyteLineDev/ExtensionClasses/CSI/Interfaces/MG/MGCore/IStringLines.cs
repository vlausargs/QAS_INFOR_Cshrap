using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSI.Data.CRUD;

namespace CSI.MG.MGCore
{
	public interface IStringLines
	{
		ICollectionLoadResponse StringLinesFn(string Lines,
		bool? IgnoreLeadingEmptyLine = true,
		string Indent = "",
		string Replace1 = "",
		string With1 = "",
		string Replace2 = "",
		string With2 = "",
		string Replace3 = "",
		string With3 = "");
	}
}
