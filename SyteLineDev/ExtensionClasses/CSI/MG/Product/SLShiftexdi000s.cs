//PROJECT NAME: ProductExt
//CLASS NAME: SLShiftexdi000s.cs

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
    [IDOExtensionClass("SLShiftexdi000s")]
    public class SLShiftexdi000s : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteShiftExceptionSP(string FromResource,
		                                  string ToResource,
		                                  DateTime? FromStartTime,
		                                  DateTime? ToStartTime,
		                                  string Exception,
		                                  short? AltNo,
		                                  ref string Infobar,
		                                  [Optional] short? StartingTransDateOffset,
		                                  [Optional] short? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeleteShiftExceptionExt = new DeleteShiftExceptionFactory().Create(appDb);
				
				var result = iDeleteShiftExceptionExt.DeleteShiftExceptionSP(FromResource,
				                                                             ToResource,
				                                                             FromStartTime,
				                                                             ToStartTime,
				                                                             Exception,
				                                                             AltNo,
				                                                             Infobar,
				                                                             StartingTransDateOffset,
				                                                             EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftExceptionSp(string FromResourceGroup,
		string ToResourceGroup,
		string ExceptionDescr,
		DateTime? StartDate,
		DateTime? EndDate,
		string Work,
		string Shift,
		int? AltNo,
		ref int? CounterItem,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftExceptionExt = new ShiftExceptionFactory().Create(appDb);
				
				var result = iShiftExceptionExt.ShiftExceptionSp(FromResourceGroup,
				ToResourceGroup,
				ExceptionDescr,
				StartDate,
				EndDate,
				Work,
				Shift,
				AltNo,
				CounterItem,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CounterItem = result.CounterItem;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
