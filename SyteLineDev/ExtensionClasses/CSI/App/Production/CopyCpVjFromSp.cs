using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Production
{
    public interface ICopyCpVjFrom
    {
        int CopyCpVjFromSp(
              ref string FromType,
              ref JobType Job,
              ref SuffixType Suffix,
              ref PsNumType PsNum,
              ref ItemType Item,
              ref RevisionType ItemRev,
              ref OperNumType StartOper,
              ref OperNumType EndOper);
    }

    public class CopyCpVjFrom: ICopyCpVjFrom
    {
        public int CopyCpVjFromSp(
              ref string FromType,
              ref JobType Job,
              ref SuffixType Suffix,
              ref PsNumType PsNum,
              ref ItemType Item,
              ref RevisionType ItemRev,
              ref OperNumType StartOper,
              ref OperNumType EndOper)
        {
            //need the bounce code here
            throw new Exception("Not Implemented");
        }
    }
}
