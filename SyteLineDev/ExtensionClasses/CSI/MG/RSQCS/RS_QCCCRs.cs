//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCCCRs.cs

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
    [IDOExtensionClass("RS_QCCCRs")]
    public class RS_QCCCRs : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CCRGetParms(ref int? CustomerReviewDays,
		ref int? CustomerFollowupDays,
		ref int? EmailEnabled,
		ref int? ValidateCustomer,
		ref int? ValidateEmployee,
		ref int? ValidateItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CCRGetParExt = new RSQC_CCRGetParFactory().Create(appDb);
				
				var result = iRSQC_CCRGetParExt.RSQC_CCRGetParms(CustomerReviewDays,
				CustomerFollowupDays,
				EmailEnabled,
				ValidateCustomer,
				ValidateEmployee,
				ValidateItem);
				
				int Severity = result.ReturnCode.Value;
				CustomerReviewDays = result.CustomerReviewDays;
				CustomerFollowupDays = result.CustomerFollowupDays;
				EmailEnabled = result.EmailEnabled;
				ValidateCustomer = result.ValidateCustomer;
				ValidateEmployee = result.ValidateEmployee;
				ValidateItem = result.ValidateItem;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ValidateCustomer(int? ValidateOk,
		string CustNum,
		int? CustSeq,
		ref string Name,
		ref string City,
		ref string State,
		ref string Zip,
		ref string Country,
		ref string Contact,
		ref string Phone,
		ref string Fax,
		ref string eMail,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ValidateCustomExt = new RSQC_ValidateCustomFactory().Create(appDb);
				
				var result = iRSQC_ValidateCustomExt.RSQC_ValidateCustomer(ValidateOk,
				CustNum,
				CustSeq,
				Name,
				City,
				State,
				Zip,
				Country,
				Contact,
				Phone,
				Fax,
				eMail,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Name = result.Name;
				City = result.City;
				State = result.State;
				Zip = result.Zip;
				Country = result.Country;
				Contact = result.Contact;
				Phone = result.Phone;
				Fax = result.Fax;
				eMail = result.eMail;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ValidateEmployee(int? ValidateOk,
		string EmployeeNum,
		ref string Name,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ValidateEmployExt = new RSQC_ValidateEmployFactory().Create(appDb);
				
				var result = iRSQC_ValidateEmployExt.RSQC_ValidateEmployee(ValidateOk,
				EmployeeNum,
				Name,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Name = result.Name;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ValidateItem(string SiteRef,
		int? ValidateOk,
		string ItemNum,
		ref string Description,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ValidateItExt = new RSQC_ValidateItFactory().Create(appDb);
				
				var result = iRSQC_ValidateItExt.RSQC_ValidateItem(SiteRef,
				ValidateOk,
				ItemNum,
				Description,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ValidateProductLine(string ProductLine,
		string ReasonCode,
		ref string Coordinator,
		ref string Resolver,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ValidateProductLiExt = new RSQC_ValidateProductLiFactory().Create(appDb);
				
				var result = iRSQC_ValidateProductLiExt.RSQC_ValidateProductLine(ProductLine,
				ReasonCode,
				Coordinator,
				Resolver,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Coordinator = result.Coordinator;
				Resolver = result.Resolver;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
