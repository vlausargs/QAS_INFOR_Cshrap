//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSWarrCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusUnit
{
    [IDOExtensionClass("FSWarrCodes")]
    public class FSWarrCodes : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSWarrEndSp(string iWarrCode,
                                  ref DateTime? iStartDate,
                                  ref int? iStartMeter,
                                  ref DateTime? oEndDate,
                                  ref int? oEndMeter,
                                  ref string Infobar,
                                  int? DefaultMeter)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSWarrEndExt = new SSSFSWarrEndFactory().Create(appDb);

                int Severity = iSSSFSWarrEndExt.SSSFSWarrEndSp(iWarrCode,
                                                               ref iStartDate,
                                                               ref iStartMeter,
                                                               ref oEndDate,
                                                               ref oEndMeter,
                                                               ref Infobar,
                                                               DefaultMeter);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetWarrCodeInfo(string iWarrCode,
		                                ref string oDescription,
		                                ref int? oDuration,
		                                ref string oDurationType,
		                                ref int? oDuration2,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetWarrCodeInExt = new SSSFSGetWarrCodeInFactory().Create(appDb);
				
				int Severity = iSSSFSGetWarrCodeInExt.SSSFSGetWarrCodeInfo(iWarrCode,
				                                                           ref oDescription,
				                                                           ref oDuration,
				                                                           ref oDurationType,
				                                                           ref oDuration2,
				                                                           ref Infobar);
				
				return Severity;
			}
		}
    }
}
