//PROJECT NAME: Production
//CLASS NAME: IPP_NextQuoteTemplate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_NextQuoteTemplate
	{
		(int? ReturnCode,
			string Key,
			string Infobar) PP_NextQuoteTemplateSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

