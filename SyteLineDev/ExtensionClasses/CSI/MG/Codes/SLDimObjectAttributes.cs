//PROJECT NAME: CodesExt
//CLASS NAME: SLDimObjectAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLDimObjectAttributes")]
	public class SLDimObjectAttributes : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckUsedbyLedgerSp(string ChangedType,
		                               string Acct,
		                               string Dimension,
		                               string Attribute,
		                               string InlineListValue,
		                               ref byte? UsedFlag,
		                               ref string OneDimension)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckUsedbyLedgerExt = new CheckUsedbyLedgerFactory().Create(appDb);
				
				int Severity = iCheckUsedbyLedgerExt.CheckUsedbyLedgerSp(ChangedType,
				                                                         Acct,
				                                                         Dimension,
				                                                         Attribute,
				                                                         InlineListValue,
				                                                         ref UsedFlag,
				                                                         ref OneDimension);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DimensionBindingSp(string DimType,
		string ObjectName,
		string TableName,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_DimensionBindingExt = new CLM_DimensionBindingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_DimensionBindingExt.CLM_DimensionBindingSp(DimType,
				ObjectName,
				TableName,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
