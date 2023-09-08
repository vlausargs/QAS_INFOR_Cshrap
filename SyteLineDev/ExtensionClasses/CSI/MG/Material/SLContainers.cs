//PROJECT NAME: MaterialExt
//CLASS NAME: SLContainers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLContainers")]
    public class SLContainers : CSIExtensionClassBase, IExtFTSLContainers
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_CheckAvaiableParentContainersSp(string ContainerNum,
		                                              string ParentContainerNum,
		                                              string Whse,
		                                              string Loc,
		                                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_CheckAvaiableParentContainersExt = new AU_CheckAvaiableParentContainersFactory().Create(appDb);
				
				int Severity = iAU_CheckAvaiableParentContainersExt.AU_CheckAvaiableParentContainersSp(ContainerNum,
				                                                                                       ParentContainerNum,
				                                                                                       Whse,
				                                                                                       Loc,
				                                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_RemoveSubContainerSp(string ContainerNum,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_RemoveSubContainerExt = new AU_RemoveSubContainerFactory().Create(appDb);
				
				int Severity = iAU_RemoveSubContainerExt.AU_RemoveSubContainerSp(ContainerNum,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_ValidateContainerSp(string Whse,
		                                  string RefType,
		                                  string ContainerNum,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_ValidateContainerExt = new AU_ValidateContainerFactory().Create(appDb);
				
				int Severity = iAU_ValidateContainerExt.AU_ValidateContainerSp(Whse,
				                                                               RefType,
				                                                               ContainerNum,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckContainerRefSp(string ContainerNum,
		                               string CoNum,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckContainerRefExt = new CheckContainerRefFactory().Create(appDb);
				
				int Severity = iCheckContainerRefExt.CheckContainerRefSp(ContainerNum,
				                                                         CoNum,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextContainerNumSp(ref string ContainerNum,
		                                 string Whse,
		                                 string Loc,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetNextContainerNumExt = new GetNextContainerNumFactory().Create(appDb);
				
				int Severity = iGetNextContainerNumExt.GetNextContainerNumSp(ref ContainerNum,
				                                                             Whse,
				                                                             Loc,
				                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ContainerAddSp(ref string ContainerNum,
		                          string Whse,
		                          string Loc,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iContainerAddExt = new ContainerAddFactory().Create(appDb);
				
				int Severity = iContainerAddExt.ContainerAddSp(ref ContainerNum,
				                                               Whse,
				                                               Loc,
				                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ContainerDeleteSp(string PContainerNum,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iContainerDeleteExt = new ContainerDeleteFactory().Create(appDb);
				
				int Severity = iContainerDeleteExt.ContainerDeleteSp(PContainerNum,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsShipmentShippedSp(string ParentContainerNum,
		                               [Optional, DefaultParameterValue((byte)0)] ref byte? Shipped,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsShipmentShippedExt = new IsShipmentShippedFactory().Create(appDb);
				
				var result = iIsShipmentShippedExt.IsShipmentShippedSp(ParentContainerNum,
				                                                       Shipped,
				                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				Shipped = result.Shipped;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateQtyForRcvIntoContainerSp(string PItem,
		                                            string PWhse,
		                                            string PLoc,
		                                            string PLot,
		                                            [Optional] string PSite,
		                                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateQtyForRcvIntoContainerExt = new ValidateQtyForRcvIntoContainerFactory().Create(appDb);
				
				var result = iValidateQtyForRcvIntoContainerExt.ValidateQtyForRcvIntoContainerSp(PItem,
				                                                                                 PWhse,
				                                                                                 PLoc,
				                                                                                 PLot,
				                                                                                 PSite,
				                                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RValContainerSp(ref string ContainerNum,
		string Whse,
		string Loc,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		ref int? AddContainer,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRValContainerExt = new RValContainerFactory().Create(appDb);
				
				var result = iRValContainerExt.RValContainerSp(ContainerNum,
				Whse,
				Loc,
				RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				AddContainer,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ContainerNum = result.ContainerNum;
				AddContainer = result.AddContainer;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_AddParentContainerSp(string ContainerNum,
		string ParentContainerNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_AddParentContainerExt = new AU_AddParentContainerFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_AddParentContainerExt.AU_AddParentContainerSp(ContainerNum,
				ParentContainerNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_GetAvaiableParentContainersSp(string ContainerNum,
			string Whse,
			string Loc)
		{
			var iAU_GetAvaiableParentContainersExt = new AU_GetAvaiableParentContainersFactory().Create(this, true);
			
			var result = iAU_GetAvaiableParentContainersExt.AU_GetAvaiableParentContainersSp(ContainerNum,
				Whse,
				Loc);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable AU_GetContainerSp(string Whse,
		string RefType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_GetContainerExt = new AU_GetContainerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_GetContainerExt.AU_GetContainerSp(Whse,
				RefType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
