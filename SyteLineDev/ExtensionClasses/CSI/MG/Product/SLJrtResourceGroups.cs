//PROJECT NAME: ProductExt
//CLASS NAME: SLJrtResourceGroups.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLJrtResourceGroups")]
    public class SLJrtResourceGroups : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ResourceOEESp(string ResOrResGrp,
		                                   string Type,
		                                   [Optional] DateTime? StartDate,
		                                   [Optional] DateTime? EndDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ResourceOEEExt = new CLM_ResourceOEEFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ResourceOEEExt.CLM_ResourceOEESp(ResOrResGrp,
				                                                   Type,
				                                                   StartDate,
				                                                   EndDate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JobRoutesOEESp(string ResourceGroup,
		string ResourceId,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		ref decimal? Availability,
		ref decimal? Performance,
		ref decimal? Quality,
		ref decimal? OEE,
		ref decimal? TotalPieces,
		ref decimal? GoodPieces,
		ref decimal? OperatingTime,
		ref decimal? AvailableProdTime,
		ref decimal? UnavailableProdTime)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJobRoutesOEEExt = new JobRoutesOEEFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJobRoutesOEEExt.JobRoutesOEESp(ResourceGroup,
				ResourceId,
				StartDate,
				EndDate,
				Availability,
				Performance,
				Quality,
				OEE,
				TotalPieces,
				GoodPieces,
				OperatingTime,
				AvailableProdTime,
				UnavailableProdTime);
				
				int Severity = result.ReturnCode.Value;
				Availability = result.Availability;
				Performance = result.Performance;
				Quality = result.Quality;
				OEE = result.OEE;
				TotalPieces = result.TotalPieces;
				GoodPieces = result.GoodPieces;
				OperatingTime = result.OperatingTime;
				AvailableProdTime = result.AvailableProdTime;
				UnavailableProdTime = result.UnavailableProdTime;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JrtRgrpUpdSp(Guid? Rowp,
		string job,
		int? suffix,
		int? oper_num,
		string rgid,
		int? qty_resources,
		string resactn,
		int? sequence)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJrtRgrpUpdExt = new JrtRgrpUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJrtRgrpUpdExt.JrtRgrpUpdSp(Rowp,
				job,
				suffix,
				oper_num,
				rgid,
				qty_resources,
				resactn,
				sequence);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_JobRouteOEESp(decimal? OEE)
		{
			var iCLM_JobRouteOEEExt = new CLM_JobRouteOEEFactory().Create(this, true);
			
			var result = iCLM_JobRouteOEEExt.CLM_JobRouteOEESp(OEE);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

    }
}
