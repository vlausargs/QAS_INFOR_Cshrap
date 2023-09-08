//PROJECT NAME: CodesExt
//CLASS NAME: SLReasons.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLReasons")]
	public class SLReasons : ExtensionClassBase, IExtFTSLReasons
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetInvAdjAcctUnitAccessSp(string PReasonCode,
		                                     string PReasonClass,
		                                     string PProductCode,
		                                     ref string PAcct,
		                                     ref string PAcctUnit1,
		                                     ref string PAcctUnit2,
		                                     ref string PAcctUnit3,
		                                     ref string PAcctUnit4,
		                                     ref string Description,
		                                     ref string PAccessUnit1,
		                                     ref string PAccessUnit2,
		                                     ref string PAccessUnit3,
		                                     ref string PAccessUnit4)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetInvAdjAcctUnitAccessExt = new GetInvAdjAcctUnitAccessFactory().Create(appDb);
				
				int Severity = iGetInvAdjAcctUnitAccessExt.GetInvAdjAcctUnitAccessSp(PReasonCode,
				                                                                     PReasonClass,
				                                                                     PProductCode,
				                                                                     ref PAcct,
				                                                                     ref PAcctUnit1,
				                                                                     ref PAcctUnit2,
				                                                                     ref PAcctUnit3,
				                                                                     ref PAcctUnit4,
				                                                                     ref Description,
				                                                                     ref PAccessUnit1,
				                                                                     ref PAccessUnit2,
				                                                                     ref PAccessUnit3,
				                                                                     ref PAccessUnit4);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ReasonGetInvAdjAcctSp(string ReasonCode,
		                                 string ReasonClass,
		                                 string Item,
		                                 ref string Acct,
		                                 ref string AcctUnit1,
		                                 ref string AcctUnit2,
		                                 ref string AcctUnit3,
		                                 ref string AcctUnit4,
		                                 ref string AccessUnit1,
		                                 ref string AccessUnit2,
		                                 ref string AccessUnit3,
		                                 ref string AccessUnit4,
		                                 ref string Description,
		                                 ref string Infobar,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? ByContainer,
		ref byte? AcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iReasonGetInvAdjAcctExt = new ReasonGetInvAdjAcctFactory().Create(appDb);
				
				var result = iReasonGetInvAdjAcctExt.ReasonGetInvAdjAcctSp(ReasonCode,
				                                                           ReasonClass,
				                                                           Item,
				                                                           Acct,
				                                                           AcctUnit1,
				                                                           AcctUnit2,
				                                                           AcctUnit3,
				                                                           AcctUnit4,
				                                                           AccessUnit1,
				                                                           AccessUnit2,
				                                                           AccessUnit3,
				                                                           AccessUnit4,
				                                                           Description,
				                                                           Infobar,
				                                                           ByContainer,
				                                                           AcctIsControl);
				
				int Severity = result.ReturnCode.Value;
				Acct = result.Acct;
				AcctUnit1 = result.AcctUnit1;
				AcctUnit2 = result.AcctUnit2;
				AcctUnit3 = result.AcctUnit3;
				AcctUnit4 = result.AcctUnit4;
				AccessUnit1 = result.AccessUnit1;
				AccessUnit2 = result.AccessUnit2;
				AccessUnit3 = result.AccessUnit3;
				AccessUnit4 = result.AccessUnit4;
				Description = result.Description;
				Infobar = result.Infobar;
				AcctIsControl = result.AcctIsControl;
				return Severity;
			}
		}
    }
}
