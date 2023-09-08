//PROJECT NAME: VendorExt
//CLASS NAME: SLPoRcpts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLPoRcpts")]
	public class SLPoRcpts : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateGrnLineSp(string VendNum,
		string GrnNum,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? RcvdDate,
		int? DateSeq,
		int? FromPo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateGrnLineExt = new GenerateGrnLineFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateGrnLineExt.GenerateGrnLineSp(VendNum,
				GrnNum,
				PoNum,
				PoLine,
				PoRelease,
				RcvdDate,
				DateSeq,
				FromPo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WBPoRcptReturnPercentageSp(DateTime? AsOfDate,
		int? KPINum,
		ref decimal? Amount,
		[Optional] string Parm1,
		[Optional] string Parm2,
		[Optional] string Parm3,
		[Optional] string Parm4,
		[Optional] string Parm5,
		[Optional] string Parm6,
		[Optional] string Parm7,
		[Optional] string Parm8,
		[Optional] string Parm9,
		[Optional] string Parm10,
		[Optional] string Parm11,
		[Optional] string Parm12,
		[Optional] string Parm13,
		[Optional] string Parm14,
		[Optional] string Parm15,
		[Optional] string Parm16,
		[Optional] string Parm17,
		[Optional] string Parm18,
		[Optional] string Parm19,
		[Optional] string Parm20,
		[Optional] string Parm21,
		[Optional] string Parm22,
		[Optional] string Parm23,
		[Optional] string Parm24,
		[Optional] string Parm25,
		[Optional] string Parm26,
		[Optional] string Parm27,
		[Optional] string Parm28,
		[Optional] string Parm29,
		[Optional] string Parm30,
		[Optional] string Parm31,
		[Optional] string Parm32,
		[Optional] string Parm33,
		[Optional] string Parm34,
		[Optional] string Parm35,
		[Optional] string Parm36,
		[Optional] string Parm37,
		[Optional] string Parm38,
		[Optional] string Parm39,
		[Optional] string Parm40,
		[Optional] string Parm41,
		[Optional] string Parm42,
		[Optional] string Parm43,
		[Optional] string Parm44,
		[Optional] string Parm45,
		[Optional] string Parm46,
		[Optional] string Parm47,
		[Optional] string Parm48,
		[Optional] string Parm49,
		[Optional] string Parm50)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iWBPoRcptReturnPercentageExt = new WBPoRcptReturnPercentageFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iWBPoRcptReturnPercentageExt.WBPoRcptReturnPercentageSp(AsOfDate,
				KPINum,
				Amount,
				Parm1,
				Parm2,
				Parm3,
				Parm4,
				Parm5,
				Parm6,
				Parm7,
				Parm8,
				Parm9,
				Parm10,
				Parm11,
				Parm12,
				Parm13,
				Parm14,
				Parm15,
				Parm16,
				Parm17,
				Parm18,
				Parm19,
				Parm20,
				Parm21,
				Parm22,
				Parm23,
				Parm24,
				Parm25,
				Parm26,
				Parm27,
				Parm28,
				Parm29,
				Parm30,
				Parm31,
				Parm32,
				Parm33,
				Parm34,
				Parm35,
				Parm36,
				Parm37,
				Parm38,
				Parm39,
				Parm40,
				Parm41,
				Parm42,
				Parm43,
				Parm44,
				Parm45,
				Parm46,
				Parm47,
				Parm48,
				Parm49,
				Parm50);
				
				int Severity = result.ReturnCode.Value;
				Amount = result.Amount;
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
				UseBuyRate,
				TRate,
				PossibleDate,
				Amount1,
				Amount2,
				Amount3,
				Amount4,
				Amount5,
				Amount6,
				Amount7,
				Amount8,
				Amount9,
				Amount10,
				Amount11,
				Amount12,
				Amount13,
				Amount14,
				Amount15,
				Amount16,
				Amount17,
				Amount18,
				Amount19,
				Amount20,
				Amount21,
				Amount22,
				Amount23,
				Amount24,
				Amount25,
				Amount26,
				Amount27,
				Amount28,
				Amount29,
				Amount30,
				Amount31,
				Amount32,
				Amount33,
				Amount34,
				Amount35,
				Amount36,
				Amount37,
				Amount38,
				Amount39,
				Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
