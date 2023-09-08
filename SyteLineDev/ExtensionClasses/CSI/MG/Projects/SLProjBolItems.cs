//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjBolItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Data.RecordSets;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjBolItems")]
	public class SLProjBolItems : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemDescriptionSp(string Item,
		                             ref string Description,
		                             ref decimal? UnitWeight,
		                             ref string UM)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemDescriptionExt = new ItemDescriptionFactory().Create(appDb);
				
				int Severity = iItemDescriptionExt.ItemDescriptionSp(Item,
				                                                     ref Description,
				                                                     ref UnitWeight,
				                                                     ref UM);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SeqProjBolValSp(string ProjNum,
		string BolNum,
		int? TaskNum,
		int? Seq,
		ref string Item,
		ref string Description,
		ref decimal? Qty,
		ref string UM,
		ref decimal? Weight,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSeqProjBolValExt = new SeqProjBolValFactory().Create(appDb);
				
				var result = iSeqProjBolValExt.SeqProjBolValSp(ProjNum,
				BolNum,
				TaskNum,
				Seq,
				Item,
				Description,
				Qty,
				UM,
				Weight,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Description = result.Description;
				Qty = result.Qty;
				UM = result.UM;
				Weight = result.Weight;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BolItemSetGloVarSp(int? UpdateASNWeight,
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
