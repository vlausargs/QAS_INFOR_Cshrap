//PROJECT NAME: Data
//CLASS NAME: IGetAmtMasks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetAmtMasks
	{
		(int? ReturnCode,
			string PAmtFormat,
			string PAmtTotFormat,
			string PCstPrcFormat) GetAmtMasksSp(
			string PCurrCode,
			string PAmtFormat = null,
			string PAmtTotFormat = null,
			string PCstPrcFormat = null);
	}
}

