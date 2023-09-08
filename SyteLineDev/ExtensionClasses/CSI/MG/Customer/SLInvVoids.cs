//PROJECT NAME: CustomerExt
//CLASS NAME: SLInvVoids.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLInvVoids")]
	public class SLInvVoids : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InvVoidSequenceSp(string PArtranType,
		                                       string PVoidThroughInvNum,
		                                       string PStartingInvNum,
		                                       string PEndingInvNum,
		                                       string Pinv_category)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_InvVoidSequenceExt = new CLM_InvVoidSequenceFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_InvVoidSequenceExt.CLM_InvVoidSequenceSp(PArtranType,
				                                                             PVoidThroughInvNum,
				                                                             PStartingInvNum,
				                                                             PEndingInvNum,
				                                                             Pinv_category);
				
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateInvSequenceSp(string PArtranType,
		string PInvCategory,
		ref string PStartingInvNum,
		ref string PEndingInvNum,
		ref DateTime? PStartingInvDate,
		ref DateTime? PEndingInvDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateInvSequenceExt = new ValidateInvSequenceFactory().Create(appDb);
				
				var result = iValidateInvSequenceExt.ValidateInvSequenceSp(PArtranType,
				PInvCategory,
				PStartingInvNum,
				PEndingInvNum,
				PStartingInvDate,
				PEndingInvDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PStartingInvNum = result.PStartingInvNum;
				PEndingInvNum = result.PEndingInvNum;
				PStartingInvDate = result.PStartingInvDate;
				PEndingInvDate = result.PEndingInvDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateInvVoidSP(string VInvNum,
			string Type,
			ref string Infobar)
		{
			var iValidateInvVoidExt = new ValidateInvVoidFactory().Create(this, true);

			var result = iValidateInvVoidExt.ValidateInvVoidSP(VInvNum,
				Type,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoidInvPostSp(string PArtranType,
		string PInvNum,
		string PReason,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoidInvPostExt = new VoidInvPostFactory().Create(appDb);
				
				var result = iVoidInvPostExt.VoidInvPostSp(PArtranType,
				PInvNum,
				PReason,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
