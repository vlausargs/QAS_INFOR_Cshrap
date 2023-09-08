//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCtmpsers.cs

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
	[IDOExtensionClass("RS_QCtmpsers")]
	public class RS_QCtmpsers : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SerialCheckSp(string SerNum,
		int? RcvNum,
		ref int? o_ErrorCode,
		ref string o_Messages,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SerialCheckExt = new RSQC_SerialCheckFactory().Create(appDb);
				
				var result = iRSQC_SerialCheckExt.RSQC_SerialCheckSp(SerNum,
				RcvNum,
				o_ErrorCode,
				o_Messages,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_ErrorCode = result.o_ErrorCode;
				o_Messages = result.o_Messages;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SerialSaveSp(string SerNum,
		string NewStat,
		string Item,
		int? RcvrNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SerialSaveExt = new RSQC_SerialSaveFactory().Create(appDb);
				
				var result = iRSQC_SerialSaveExt.RSQC_SerialSaveSp(SerNum,
				NewStat,
				Item,
				RcvrNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SetUptmpserSp(string RefType,
		string RefNum,
		int? RefLine,
		int? RefRelease,
		int? OperNum,
		int? TestSeq,
		string MrrNum,
		int? RcvrNum,
		string Item,
		string Entity,
		ref int? SerialTracked,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SetUptmpserExt = new RSQC_SetUptmpserFactory().Create(appDb);
				
				var result = iRSQC_SetUptmpserExt.RSQC_SetUptmpserSp(RefType,
				RefNum,
				RefLine,
				RefRelease,
				OperNum,
				TestSeq,
				MrrNum,
				RcvrNum,
				Item,
				Entity,
				SerialTracked,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				SerialTracked = result.SerialTracked;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
