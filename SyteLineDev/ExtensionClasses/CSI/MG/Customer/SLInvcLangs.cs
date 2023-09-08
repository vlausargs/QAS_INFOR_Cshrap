//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvcLangs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInvcLangs")]
	public class SLInvcLangs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetMultiLingualDefaultTextSp(ref string CoparmCoText1,
		                                        ref string CoparmCoText2,
		                                        ref string CoparmCoText3,
		                                        ref string InvparmTrnTxt1,
		                                        ref string InvparmTrnTxt2,
		                                        ref string InvparmTrnTxt3,
                                                ref string FlatRateCompensationText,
                                                ref string LatePayPenaltyRateText,
                                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetMultiLingualDefaultTextExt = new GetMultiLingualDefaultTextFactory().Create(appDb);
				
				int Severity = iGetMultiLingualDefaultTextExt.GetMultiLingualDefaultTextSp(ref CoparmCoText1,
				                                                                           ref CoparmCoText2,
				                                                                           ref CoparmCoText3,
				                                                                           ref InvparmTrnTxt1,
				                                                                           ref InvparmTrnTxt2,
				                                                                           ref InvparmTrnTxt3,
                                                                                           ref FlatRateCompensationText,
                                                                                           ref LatePayPenaltyRateText,
                                                                                           ref Infobar);
				
				return Severity;
			}
		}
	}
}
