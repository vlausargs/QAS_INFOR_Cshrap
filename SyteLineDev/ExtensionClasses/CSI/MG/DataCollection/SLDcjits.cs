//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcjits.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.DataCollection;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Data.RecordSets;

namespace CSI.MG.DataCollection
{
    [IDOExtensionClass("SLDcjits")]
    public class SLDcjits : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcLotValidSp(string pItem,
		                        string pLot,
		                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDCLotValidExt = new DCLotValidFactory().Create(appDb);
				
				int Severity = iDCLotValidExt.DCLotValidSP(pItem,
				                                           pLot,
				                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcjitDSp(string Status,
		                    decimal? FromTransNum,
		                    decimal? ToTransNum,
		                    DateTime? FromTransDate,
		                    DateTime? ToTransDate,
		                    ref string Infobar,
		                    [Optional] short? StartingTransDateOffset,
		                    [Optional] short? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcjitDExt = new DcjitDFactory().Create(appDb);
				
				var result = iDcjitDExt.DcjitDSp(Status,
				                                 FromTransNum,
				                                 ToTransNum,
				                                 FromTransDate,
				                                 ToTransDate,
				                                 Infobar,
				                                 StartingTransDateOffset,
				                                 EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcjitPSp(DateTime? TransDate,
		                    ref string Infobar,
		                    [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcjitPExt = new DcjitPFactory().Create(appDb);
				
				var result = iDcjitPExt.DcjitPSp(TransDate,
				                                 Infobar,
				                                 DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcAJitSp(string TTermId,
		string TTransType,
		string TEmpNum,
		DateTime? TTransDate,
		decimal? TCompleted,
		string TItem,
		string TShift,
		string TLocation,
		string TLot,
		string TCurWhse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDcAJitExt = new DcAJitFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDcAJitExt.DcAJitSp(TTermId,
				TTransType,
				TEmpNum,
				TTransDate,
				TCompleted,
				TItem,
				TShift,
				TLocation,
				TLot,
				TCurWhse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcjitLogErrorSp(int? PTransNum,
		int? PCanOverride,
		string ErrorMsg)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDcjitLogErrorExt = new DcjitLogErrorFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDcjitLogErrorExt.DcjitLogErrorSp(PTransNum,
				PCanOverride,
				ErrorMsg);
				
				int Severity = result.Value;
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDcparmAutopostSp(string AutoPostFieldName,
		ref int? AutoPostFlag,
		ref string EscFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDcparmAutopostEscFlagExt = new GetDcparmAutopostEscFlagFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDcparmAutopostEscFlagExt.GetDcparmAutopostEscFlagSp(AutoPostFieldName,
				AutoPostFlag,
				EscFlag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				AutoPostFlag = result.AutoPostFlag;
				EscFlag = result.EscFlag;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}