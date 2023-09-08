//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCGages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCGages")]
    public class RS_QCGages : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GageCheckSp(Guid? i_gage,
		ref int? o_gage_expired,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GageCheckExt = new RSQC_GageCheckFactory().Create(appDb);
				
				var result = iRSQC_GageCheckExt.RSQC_GageCheckSp(i_gage,
				o_gage_expired,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_gage_expired = result.o_gage_expired;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ValidateDeptSp(int? ValidateDept,
		string Dept,
		ref string Description,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ValidateDeptExt = new RSQC_ValidateDeptFactory().Create(appDb);
				
				var result = iRSQC_ValidateDeptExt.RSQC_ValidateDeptSp(ValidateDept,
				Dept,
				Description,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ValidateVendorSp(int? ValidateVendor,
		string VendNum,
		ref string Name,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ValidateVendorExt = new RSQC_ValidateVendorFactory().Create(appDb);
				
				var result = iRSQC_ValidateVendorExt.RSQC_ValidateVendorSp(ValidateVendor,
				VendNum,
				Name,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Name = result.Name;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CalcIntervalSp(DateTime? Date,
			int? Interval,
			ref DateTime? NewDate,
			ref string Infobar)
		{
			var iRSQC_CalcIntervalExt = this.GetService<IRSQC_CalcInterval>();

			var result = iRSQC_CalcIntervalExt.RSQC_CalcIntervalSp(Date,
				Interval,
				NewDate,
				Infobar);

			NewDate = result.NewDate;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}
	}
}


