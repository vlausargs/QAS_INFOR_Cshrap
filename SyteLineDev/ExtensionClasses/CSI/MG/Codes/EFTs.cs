//PROJECT NAME: CodesExt
//CLASS NAME: EFTs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("EFTs")]
    public class EFTs : ExtensionClassBase
    {


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EFTCreateEventHandlerSp(string MapId,
                                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEFTCreateEventHandlerExt = new EFTCreateEventHandlerFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iEFTCreateEventHandlerExt.EFTCreateEventHandlerSp(MapId,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EFTMapCreateDataViewSp(string MapId,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEFTMapCreateDataViewExt = new EFTMapCreateDataViewFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEFTMapCreateDataViewExt.EFTMapCreateDataViewSp(MapId,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
    }
}

