using CSI.Data.SQL.UDDT;
using CSI.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface ITagErrorMessage
    {
        int TagErrorMessageSp(string Infobar,
                                    ref string TaggedMessageOrSegment,
                                    ref string UntaggedRemainder);
    }
    public class TagErrorMessage : ITagErrorMessage
    {
        readonly IStringUtil stringUtil;

        public TagErrorMessage(IStringUtil stringUtil)
        {
            this.stringUtil = stringUtil ?? throw new ArgumentNullException(nameof(stringUtil));
        }

        public int TagErrorMessageSp(string Infobar,
                                    ref string TaggedMessageOrSegment,
                                    ref string UntaggedRemainder)
        {
            TaggedMessageOrSegment = null;
            UntaggedRemainder = null;

            if (Infobar == null || Infobar == "")
                return 0;


            string MsgTag = "<MsgTag>";
            string ContinuationPrefix = "_";

            if (Infobar.ToString().Substring(1, stringUtil.Len(MsgTag).GetValueOrDefault()) == MsgTag)
                return 0;

            int MaxLen = 1881;

            if (stringUtil.Len(Infobar) > MaxLen)
            {
                TaggedMessageOrSegment = MsgTag + Infobar.ToString().Substring(1, MaxLen - 1) + ContinuationPrefix + MsgTag;
                UntaggedRemainder = Infobar.ToString().Substring(MaxLen, stringUtil.Len(Infobar).GetValueOrDefault() - MaxLen + 1);
            }
            else
                TaggedMessageOrSegment = MsgTag + Infobar + MsgTag;

            return 0;
        }
    }
}
