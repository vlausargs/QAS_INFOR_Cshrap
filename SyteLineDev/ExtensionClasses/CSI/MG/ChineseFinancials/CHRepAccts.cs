//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHRepAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHRepAccts")]
    public class CHRepAccts : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSRepAcctsNextSeqSp(decimal? BookKey,
			ref decimal? SeqCount,
			ref string InfoBar)
        {
            var iCHSRepAcctsNextSeqExt = new CHSRepAcctsNextSeqFactory().Create(this, true);

            var result = iCHSRepAcctsNextSeqExt.CHSRepAcctsNextSeqSp(BookKey,
				SeqCount,
				InfoBar);

            SeqCount = result.SeqCount;
            InfoBar = result.InfoBar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSRepAcctsReSequenceSp(decimal? BookKey,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSRepAcctsReSequenceExt = new CHSRepAcctsReSequenceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSRepAcctsReSequenceExt.CHSRepAcctsReSequenceSp(BookKey,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
    }
}
