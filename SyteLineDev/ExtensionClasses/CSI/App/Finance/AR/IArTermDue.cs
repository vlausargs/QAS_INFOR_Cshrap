//PROJECT NAME: Data
//CLASS NAME: IArTermDue.cs

using System;
using CSI.Data.CRUD;

namespace CSI.Finance.AR
{
    public interface IArTermDue
    {
        ICollectionLoadResponse ArTermDueFn(
            string PSite_ref,
            string PCustNum,
            string PInvNum,
            int? PInvSeq,
            DateTime? CutoffDate);
    }
}
