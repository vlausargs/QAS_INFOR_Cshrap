//PROJECT NAME: MaterialExt
//CLASS NAME: SLBolItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLBolItems")]
    public class SLBolItems : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetASNLineInfoSp(string BolItemRefNum,
            string BolItemBolNum,
            int? BolItemRefLine,
            ref string BolItemItem,
            ref string BolItemDescription,
            ref decimal? BolItemQty,
            ref string BolItemUM,
            ref decimal? BolItemWeight,
            ref int? ItemSerialTracked,
            ref decimal? ItemUnitWeight)
        {
            var iGetASNLineInfoExt = new GetASNLineInfoFactory().Create(this, true);

            var result = iGetASNLineInfoExt.GetASNLineInfoSp(BolItemRefNum,
                BolItemBolNum,
                BolItemRefLine,
                BolItemItem,
                BolItemDescription,
                BolItemQty,
                BolItemUM,
                BolItemWeight,
                ItemSerialTracked,
                ItemUnitWeight);

            BolItemItem = result.BolItemItem;
            BolItemDescription = result.BolItemDescription;
            BolItemQty = result.BolItemQty;
            BolItemUM = result.BolItemUM;
            BolItemWeight = result.BolItemWeight;
            ItemSerialTracked = result.ItemSerialTracked;
            ItemUnitWeight = result.ItemUnitWeight;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetNextASNRefLineSp(string BolitemRefNum,
                                       string BolitemBolNum,
                                       ref short? BolitemRefLine,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetNextASNRefLineExt = new GetNextASNRefLineFactory().Create(appDb);

                TrnLineType oBolitemRefLine = BolitemRefLine;
                InfobarType oInfobar = Infobar;

                int Severity = iGetNextASNRefLineExt.GetNextASNRefLineSp(BolitemRefNum,
                                                                  BolitemBolNum,
                                                                  ref oBolitemRefLine,
                                                                  ref oInfobar);

                BolitemRefLine = oBolitemRefLine;
                Infobar = oInfobar;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BolitemSetGloVarSp(int? UpdateASNWeight,
		int? UpdateASNCharges)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBolItemSetGloVarExt = new BolItemSetGloVarFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBolItemSetGloVarExt.BolItemSetGloVarSp(UpdateASNWeight,
				UpdateASNCharges);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
