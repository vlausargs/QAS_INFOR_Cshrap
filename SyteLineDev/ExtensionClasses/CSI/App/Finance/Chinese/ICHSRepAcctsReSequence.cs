//PROJECT NAME: Finance
//CLASS NAME: ICHSRepAcctsReSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSRepAcctsReSequence
	{
		(int? ReturnCode, string InfoBar) CHSRepAcctsReSequenceSp(decimal? BookKey,
		string InfoBar);
	}
}

