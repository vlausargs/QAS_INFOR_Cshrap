//PROJECT NAME: Production
//CLASS NAME: ISetProjectTaskTreeOutline.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ISetProjectTaskTreeOutline
	{
		(int? ReturnCode, string OutLineNumber,
		string Infobar) SetProjectTaskTreeOutlineSp(string ProjNum,
		int? TaskNum,
		int? ParentTaskNum,
		string IndentOrOutdent = "INDENT",
		string OutLineNumber = null,
		string Infobar = null);
	}
}

