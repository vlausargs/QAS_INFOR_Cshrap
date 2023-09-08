//PROJECT NAME: ProductExt
//CLASS NAME: SLShift000s.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
	[IDOExtensionClass("SLShift000s")]
	public class SLShift000s : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftSaveSp(string ShiftId,
		string Descr,
		int? SDay,
		string STime,
		int? EDay,
		string ETime,
		string MustCompFg,
		string OverrunFg,
		int? UpdateFlag,
		Guid? RowPointer,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftSaveExt = new ShiftSaveFactory().Create(appDb);
				
				var result = iShiftSaveExt.ShiftSaveSp(ShiftId,
				Descr,
				SDay,
				STime,
				EDay,
				ETime,
				MustCompFg,
				OverrunFg,
				UpdateFlag,
				RowPointer,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShopCalendarDeleteSp(string ShiftId,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShopCalendarDeleteExt = new ShopCalendarDeleteFactory().Create(appDb);
				
				var result = iShopCalendarDeleteExt.ShopCalendarDeleteSp(ShiftId,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShopCalendarSaveSp(string ShiftId,
		string Descr,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShopCalendarSaveExt = new ShopCalendarSaveFactory().Create(appDb);
				
				var result = iShopCalendarSaveExt.ShopCalendarSaveSp(ShiftId,
				Descr,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TickCalSp(string StartCal,
		[Optional] string EndCal,
		int? AltNo,
		[Optional] DateTime? StartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTickCalExt = new TickCalFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTickCalExt.TickCalSp(StartCal,
				EndCal,
				AltNo,
				StartDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
