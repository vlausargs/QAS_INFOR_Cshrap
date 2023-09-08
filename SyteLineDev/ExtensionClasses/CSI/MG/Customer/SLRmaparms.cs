//PROJECT NAME: CustomerExt
//CLASS NAME: SLRmaparms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLRmaparms")]
    public class SLRmaparms : CSIExtensionClassBase, IExtFTSLRmaparms
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXGetDefRMAWhseLocSp(ref string Whse,
                                            ref string Loc,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXGetDefRMAWhseLocExt = new SSSRMXGetDefRMAWhseLocFactory().Create(appDb);

                int Severity = iSSSRMXGetDefRMAWhseLocExt.SSSRMXGetDefRMAWhseLocSp(ref Whse,
                                                                                   ref Loc,
                                                                                   ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXGetDefRMAWhseSp(ref string Whse, ref string Infobar)
		{
			var iSSSRMXGetDefRMAWhseExt = new SSSRMXGetDefRMAWhseFactory().Create(this, true);
			
			var result = iSSSRMXGetDefRMAWhseExt.SSSRMXGetDefRMAWhseSp(Whse, Infobar);
			
			Whse = result.Whse;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXGetEnableDispSp(ref int? EnableDisp, ref string Infobar)
		{
			var iSSSRMXGetEnableDispExt = new SSSRMXGetEnableDispFactory().Create(this, true);
			
			var result = iSSSRMXGetEnableDispExt.SSSRMXGetEnableDispSp(EnableDisp, Infobar);
			
			EnableDisp = result.EnableDisp;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXRMAReturnPopAddSpSp(string RmaNum,
                                           short? RmaLine,
                                           string Item,
                                           string CoNum,
                                           short? CoLine,
                                           short? CoRelease,
                                           ref decimal? MatlCost,
                                           ref decimal? LbrCost,
                                           ref decimal? FovCost,
                                           ref decimal? VovCost,
                                           ref decimal? OutCost,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXRMAReturnPopAddExt = new SSSRMXRMAReturnPopAddFactory().Create(appDb);

                int Severity = iSSSRMXRMAReturnPopAddExt.SSSRMXRMAReturnPopAddSp(RmaNum,
                                                                                 RmaLine,
                                                                                 Item,
                                                                                 CoNum,
                                                                                 CoLine,
                                                                                 CoRelease,
                                                                                 ref MatlCost,
                                                                                 ref LbrCost,
                                                                                 ref FovCost,
                                                                                 ref VovCost,
                                                                                 ref OutCost,
                                                                                 ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetRmaparmRestockFeePctSp(ref decimal? RestockFeePct)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetRmaparmRestockFeePctExt = new GetRmaparmRestockFeePctFactory().Create(appDb);
				
				int Severity = iGetRmaparmRestockFeePctExt.GetRmaparmRestockFeePctSp(ref RestockFeePct);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetRmaparmsLocSp(ref string Loc,
		                            [Optional] ref byte? TaxFreeImports)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetRmaparmsLocExt = new GetRmaparmsLocFactory().Create(appDb);
				
				var result = iGetRmaparmsLocExt.GetRmaparmsLocSp(Loc,
				                                                 TaxFreeImports);
				
				int Severity = result.ReturnCode.Value;
				Loc = result.Loc;
				TaxFreeImports = result.TaxFreeImports;
				return Severity;
			}
		}
    }
}
