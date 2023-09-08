//PROJECT NAME: Material
//CLASS NAME: IForecastPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IForecastPostSave
	{
		(int? ReturnCode, string Infobar) ForecastPostSaveSp(string Infobar);
	}
}

