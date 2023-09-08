//PROJECT NAME: CodesExt
//CLASS NAME: SLShifts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLShifts")]
	public class SLShifts : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftExistsSp(string Shift,
		ref int? ShiftExists,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftExistsExt = new ShiftExistsFactory().Create(appDb);
				
				var result = iShiftExistsExt.ShiftExistsSp(Shift,
				ShiftExists,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ShiftExists = result.ShiftExists;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateShiftSp(string Shift,
		DateTime? PEffDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateShiftExt = new ValidateShiftFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateShiftExt.ValidateShiftSp(Shift,
				PEffDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
