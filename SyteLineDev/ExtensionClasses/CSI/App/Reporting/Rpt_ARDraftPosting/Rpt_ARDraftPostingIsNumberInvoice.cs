using CSI.Data;
using CSI.MG.MGCore;
using System;


namespace CSI.Reporting
{
    public class Rpt_ARDraftPostingIsNumberInvoice : IRpt_ARDraftPostingIsNumberInvoice
    {
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IIsInteger iIsInteger;
        readonly IConvertToUtil convertToUtil;
        public Rpt_ARDraftPostingIsNumberInvoice(ISQLValueComparerUtil _sQLUtil,
           IIsInteger _iIsInteger,
           IConvertToUtil _convertToUtil)
        {
            this.sQLUtil = _sQLUtil;
            this.iIsInteger = _iIsInteger;
            this.convertToUtil = _convertToUtil;
        }
        public bool IsNumberInvoice(string TArpmtdInvNum)
        {
            return sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLNot((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(TArpmtdInvNum), 1))), (sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(TArpmtdInvNum), 1) ==true && sQLUtil.SQLGreaterThan(convertToUtil.ToInt64(TArpmtdInvNum), 0) == true)));
        }
    }
}
