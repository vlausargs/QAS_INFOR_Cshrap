//PROJECT NAME: FinanceExt
//CLASS NAME: SLTTFinstmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLTTFinstmts")]
    public class SLTTFinstmts : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSiteTypeSp([Optional] ref string Site,
		                         ref string SiteType,
		                         ref byte? SiteIsEntity,
		                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSiteTypeExt = new GetSiteTypeFactory().Create(appDb);
				
				var result = iGetSiteTypeExt.GetSiteTypeSp(Site,
				                                           SiteType,
				                                           SiteIsEntity,
				                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				Site = result.Site;
				SiteType = result.SiteType;
				SiteIsEntity = result.SiteIsEntity;
				Infobar = result.Infobar;
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinRptOutputGetPeriod1Sp(ref DateTime? YearStart,
		ref int? Period,
		ref DateTime? PeriodStart,
		ref DateTime? PeriodEnd,
		[Optional] string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFinRptOutputGetPeriod1Ext = new FinRptOutputGetPeriod1Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFinRptOutputGetPeriod1Ext.FinRptOutputGetPeriod1Sp(YearStart,
				Period,
				PeriodStart,
				PeriodEnd,
				Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				YearStart = result.YearStart;
				Period = result.Period;
				PeriodStart = result.PeriodStart;
				PeriodEnd = result.PeriodEnd;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinRptOutputGetPeriod2Sp(DateTime? YearStart,
		int? Period,
		ref DateTime? PeriodStart,
		ref DateTime? PeriodEnd,
		[Optional] string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFinRptOutputGetPeriod2Ext = new FinRptOutputGetPeriod2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFinRptOutputGetPeriod2Ext.FinRptOutputGetPeriod2Sp(YearStart,
				Period,
				PeriodStart,
				PeriodEnd,
				Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PeriodStart = result.PeriodStart;
				PeriodEnd = result.PeriodEnd;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
