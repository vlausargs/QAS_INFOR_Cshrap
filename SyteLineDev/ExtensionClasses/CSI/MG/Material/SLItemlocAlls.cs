//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemlocAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemlocAlls")]
	public class SLItemlocAlls : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemlocQtySp(string Site,
		                           string Whse,
		                           string Item,
		                           string Loc,
		                           ref decimal? QtyOnHand)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetItemlocQtyExt = new GetItemlocQtyFactory().Create(appDb);
				
				int Severity = iGetItemlocQtyExt.GetItemlocQtySp(Site,
				                                                 Whse,
				                                                 Item,
				                                                 Loc,
				                                                 ref QtyOnHand);
				
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemlocFirstRankSp(string Item,
		string Whse,
		[Optional] string Site,
		ref string Loc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemlocFirstRankExt = new ItemlocFirstRankFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemlocFirstRankExt.ItemlocFirstRankSp(Item,
				Whse,
				Site,
				Loc);
				
				int Severity = result.ReturnCode.Value;
				Loc = result.Loc;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_EmptyStockroomLocsSp([Optional] string FilterString,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_EmptyStockroomLocsExt = new CLM_EmptyStockroomLocsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_EmptyStockroomLocsExt.CLM_EmptyStockroomLocsSp(FilterString,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
