//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCTrrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCTrrs")]
	public class RS_QCTrrs : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateTrrSp(int? i_trcvr,
		ref string o_trr,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateTrrExt = new RSQC_CreateTrrFactory().Create(appDb);
				
				var result = iRSQC_CreateTrrExt.RSQC_CreateTrrSp(i_trcvr,
				o_trr,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_trr = result.o_trr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetUserSp(ref string o_user,
            ref string Infobar)
        {
            var iRSQC_GetUserExt = new RSQC_GetUserFactory().Create(this, true);

            var result = iRSQC_GetUserExt.RSQC_GetUserSp(o_user,
                Infobar);

            o_user = result.o_user;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }
    }
}
