//PROJECT NAME: AdminExt
//CLASS NAME: BILinkSiteInfos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.SQL;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("BILinkSiteInfos")]
    public class BILinkSiteInfos : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int BI_UpdateSiteSp(string DefSite,
                              ref string InforBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iBI_UpdateSiteExt = new BI_UpdateSiteFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iBI_UpdateSiteExt.BI_UpdateSiteSp(DefSite,
                InforBar);

                int Severity = result.ReturnCode.Value;
                InforBar = result.InforBar;
                return Severity;

            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int BI_Refresh_ViewsSp(string DefSite,
		                              ref string InforBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iBI_Refresh_ViewsExt = new BI_Refresh_ViewsFactory().Create(appDb);
				
				int Severity = iBI_Refresh_ViewsExt.BI_Refresh_ViewsSp(DefSite,
				                                                       ref InforBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BI_LoadLinkSiteSp([Optional] string Site,
		                             [Optional] ref string ServerName,
		                             [Optional] ref string DatabaseName,
		                             [Optional] ref string SiteName,
		                             [Optional] ref string SiteCurrCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iBI_LoadLinkSiteExt = new BI_LoadLinkSiteFactory().Create(appDb);
				
				var result = iBI_LoadLinkSiteExt.BI_LoadLinkSiteSp(Site,
				                                                   ServerName,
				                                                   DatabaseName,
				                                                   SiteName,
				                                                   SiteCurrCode);
				
				int Severity = result.ReturnCode.Value;
				ServerName = result.ServerName;
				DatabaseName = result.DatabaseName;
				SiteName = result.SiteName;
				SiteCurrCode = result.SiteCurrCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BI_SaveBILinkSitesSp(string ServerName,
		string DatabaseName,
		string Site,
		string Description,
		[Optional] Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iBI_SaveBILinkSitesExt = new BI_SaveBILinkSitesFactory().Create(appDb);
				
				var result = iBI_SaveBILinkSitesExt.BI_SaveBILinkSitesSp(ServerName,
				DatabaseName,
				Site,
				Description,
				RowPointer);
				
				
				return result.Value;
			}
		}
    }
}
