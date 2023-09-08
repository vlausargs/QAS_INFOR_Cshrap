//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPOperTypeFormulaTerms.cs

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
	[IDOExtensionClass("PPOperTypeFormulaTerms")]
	public class PPOperTypeFormulaTerms : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FormulaTermValidateSp(string PropertyName,
		string CollectionName,
		[Optional] string OperationType,
		[Optional, DefaultParameterValue(0)] int? IncludeKeySequence,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFormulaTermValidateExt = new FormulaTermValidateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFormulaTermValidateExt.FormulaTermValidateSp(PropertyName,
				CollectionName,
				OperationType,
				IncludeKeySequence,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PP_CLM_OperationTypeFormulasSp(string CollectionName,
		[Optional] string OperationType,
		[Optional, DefaultParameterValue(0)] int? IncludeKeySequence)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPP_CLM_OperationTypeFormulasExt = new PP_CLM_OperationTypeFormulasFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPP_CLM_OperationTypeFormulasExt.PP_CLM_OperationTypeFormulasSp(CollectionName,
				OperationType,
				IncludeKeySequence);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
