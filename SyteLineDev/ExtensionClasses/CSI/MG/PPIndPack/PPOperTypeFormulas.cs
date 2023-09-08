//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPOperTypeFormulas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.PrintingPackaging;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PPIndPack
{
	[IDOExtensionClass("PPOperTypeFormulas")]
	public class PPOperTypeFormulas : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_ValidateCaptionWithFormulaSp(string OperationType,
		                                           string OldCaptionVal,
		                                           string NewCaptionVal,
		                                           ref string Infobar,
		                                           ref string PromptMsg,
		                                           ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_ValidateCaptionWithFormulaExt = new PP_ValidateCaptionWithFormulaFactory().Create(appDb);
				
				var result = iPP_ValidateCaptionWithFormulaExt.PP_ValidateCaptionWithFormulaSp(OperationType,
				                                                                               OldCaptionVal,
				                                                                               NewCaptionVal,
				                                                                               Infobar,
				                                                                               PromptMsg,
				                                                                               PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_GetFormulaStringsSp(string CollectionName,
		string OperationType,
		string PropertyName,
		ref string PropertyString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPP_GetFormulaStringsExt = new PP_GetFormulaStringsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPP_GetFormulaStringsExt.PP_GetFormulaStringsSp(CollectionName,
				OperationType,
				PropertyName,
				PropertyString);
				
				int Severity = result.ReturnCode.Value;
				PropertyString = result.PropertyString;
				return Severity;
			}
		}
	}
}
