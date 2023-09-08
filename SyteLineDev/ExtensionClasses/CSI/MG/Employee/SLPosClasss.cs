//PROJECT NAME: MG
//CLASS NAME: SLPosClasss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Employee
{
	[IDOExtensionClass("SLPosClasss")]
	public class SLPosClasss : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrNextPosDetSp(string Position,
		ref int? JobDetail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHrNextPosDetExt = new HrNextPosDetFactory().Create(appDb);
				
				var result = iHrNextPosDetExt.HrNextPosDetSp(Position,
				JobDetail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				JobDetail = result.JobDetail;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrNextPosSp(ref string PosDefault,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHrNextPosExt = new HrNextPosFactory().Create(appDb);
				
				var result = iHrNextPosExt.HrNextPosSp(PosDefault,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PosDefault = result.PosDefault;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrVerifyDelPosDetSp(string JobId,
		int? JobDetail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHrVerifyDelPosDetExt = new HrVerifyDelPosDetFactory().Create(appDb);
				
				var result = iHrVerifyDelPosDetExt.HrVerifyDelPosDetSp(JobId,
				JobDetail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int HrVerifyDelPosSp(string JobId,
		int? JobDetail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHrVerifyDelPosExt = new HrVerifyDelPosFactory().Create(appDb);
				
				var result = iHrVerifyDelPosExt.HrVerifyDelPosSp(JobId,
				JobDetail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
