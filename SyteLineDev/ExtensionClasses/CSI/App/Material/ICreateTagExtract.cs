//PROJECT NAME: Material
//CLASS NAME: ICreateTagExtract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICreateTagExtract
	{
		(int? ReturnCode, string Infobar) CreateTagExtractSp(string Whse,
		string Infobar);
	}
}

