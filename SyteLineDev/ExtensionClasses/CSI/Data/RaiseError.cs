using CSI.Data.SQL.UDDT;
using CSI.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
  
    public class RaiseError : IRaiseError
    {
        readonly IStringUtil stringUtil;
        readonly ITagErrorMessage tagErrorMessage;
        readonly IUntagErrorMessage untagErrorMessage;

        public RaiseError(IStringUtil stringUtil,
                            ITagErrorMessage tagErrorMessage,
                            IUntagErrorMessage untagErrorMessage)
        {
            this.stringUtil = stringUtil;
            this.tagErrorMessage = tagErrorMessage;
            this.untagErrorMessage = untagErrorMessage;
        }

        public int RaiseErrorSp(string Infobar,
                              int? Severity,
                              int State = 1,
                              params object[] optionalParams)
        {
            string LocalInfo;
            int Scanned;
            int PIndex;
            int _severity = Severity ?? 0;

            if (Infobar == null || Infobar == "")
                return 0;

            Infobar = untagErrorMessage.UntagErrorMessageFn(Infobar);
            LocalInfo = Infobar;
            Infobar = "";
            Scanned = 0;

            while (Scanned == 0)
            {
                int? charIndex = stringUtil.CharIndex(LocalInfo, "%", 1);
                PIndex = charIndex ?? 0;

                if (PIndex > 0)
                {
                    Infobar = Infobar + LocalInfo.ToString().Substring(1, PIndex) + "%";
                    LocalInfo = LocalInfo.ToString().Substring(PIndex + 1, stringUtil.Len(LocalInfo).GetValueOrDefault() - PIndex);
                }
                else
                {
                    Scanned = 1;
                    if (stringUtil.Len(Infobar) == 0)
                        Infobar = LocalInfo;
                    else if (stringUtil.Len(LocalInfo) > 0)
                        Infobar = Infobar + LocalInfo;
                    break;
                }
            }

            string TaggedMessageOrSegment;

            Infobar = Infobar ?? "";

            while (Infobar != "")
            {
                TaggedMessageOrSegment = null;
                string _Infobar = Infobar;
                tagErrorMessage.TagErrorMessageSp(Infobar, ref TaggedMessageOrSegment, ref _Infobar);
                TaggedMessageOrSegment = TaggedMessageOrSegment ?? "";                
                DbException dbException = new DbException(-1, _severity, State, TaggedMessageOrSegment);
                throw dbException;
            }

            return 0;
        }
    }
}


