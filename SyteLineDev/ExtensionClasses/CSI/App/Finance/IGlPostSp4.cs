//PROJECT NAME: Finance
//CLASS NAME: IGlPost4.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlPost4
	{
		(int? ReturnCode, string Infobar) GlPostSp4(string Infobar);
	}
}

