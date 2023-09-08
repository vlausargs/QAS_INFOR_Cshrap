//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemCatalogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemCatalogs")]
	public class SLItemCatalogs : CSIExtensionClassBase, ISLItemCatalogs
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyPortalCatalogSp(string CopyToCatalogID,
		                               Guid? CatalogRowPointer,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCopyPortalCatalogExt = new CopyPortalCatalogFactory().Create(appDb);
				
				int Severity = iCopyPortalCatalogExt.CopyPortalCatalogSp(CopyToCatalogID,
				                                                         CatalogRowPointer,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetCustomerCatalogRowPointerSp(string CustNum,
			ref Guid? CatalogRowPointer,
			ref string Infobar)
        {
            var iGetCustomerCatalogRowPointerExt = new GetCustomerCatalogRowPointerFactory().Create(this, true);

            var result = iGetCustomerCatalogRowPointerExt.GetCustomerCatalogRowPointerSp(CustNum,
				CatalogRowPointer,
				Infobar);

            CatalogRowPointer = result.CatalogRowPointer;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyPortalCatalogValidationSp(string CopyToCatalogID,
		                                         Guid? CatalogRowPointer,
		                                         [Optional] ref string Prompt,
		                                         [Optional] ref string PromptButtons,
		                                         [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCopyPortalCatalogValidationExt = new CopyPortalCatalogValidationFactory().Create(appDb);
				
				var result = iCopyPortalCatalogValidationExt.CopyPortalCatalogValidationSp(CopyToCatalogID,
				                                                                           CatalogRowPointer,
				                                                                           Prompt,
				                                                                           PromptButtons,
				                                                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}











		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ActivateAllCatalogsSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iActivateAllCatalogsExt = new ActivateAllCatalogsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iActivateAllCatalogsExt.ActivateAllCatalogsSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ActivateCatalogSp(string CatalogID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iActivateCatalogExt = new ActivateCatalogFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iActivateCatalogExt.ActivateCatalogSp(CatalogID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BuildAllCatalogsSp(string Status,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBuildAllCatalogsExt = new BuildAllCatalogsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBuildAllCatalogsExt.BuildAllCatalogsSp(Status,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BuildAndActivateCatalogsSp(int? RebuildAllPendingCatalogs,
		int? ActivateAllPendingCatalogs,
		int? RebuildAllActiveCatalogs,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBuildAndActivateCatalogsExt = new BuildAndActivateCatalogsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBuildAndActivateCatalogsExt.BuildAndActivateCatalogsSp(RebuildAllPendingCatalogs,
				ActivateAllPendingCatalogs,
				RebuildAllActiveCatalogs,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BuildCatalogItemsSp(Guid? CatalogRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBuildCatalogItemsExt = new BuildCatalogItemsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBuildCatalogItemsExt.BuildCatalogItemsSp(CatalogRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
