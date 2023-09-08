//PROJECT NAME: Finance
//CLASS NAME: ICHSRepAcctsNextSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
    public interface ICHSRepAcctsNextSeq
    {
            (int? ReturnCode,
            decimal? SeqCount,
            string InfoBar) 
        CHSRepAcctsNextSeqSp(
            decimal? BookKey,
            decimal? SeqCount,
            string InfoBar);
    }
}

