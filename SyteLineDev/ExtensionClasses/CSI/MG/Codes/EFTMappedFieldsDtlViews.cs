//PROJECT NAME: CodesExt
//CLASS NAME: EFTMappedFieldsDtlViews.cs

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
	[IDOExtensionClass("EFTMappedFieldsDtlViews")]
	public class EFTMappedFieldsDtlViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EFTFileDtlUpSp(string FileName,
		                          int? Sequence,
		                          byte? BankRecon,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEFTFileDtlUpExt = new EFTFileDtlUpFactory().Create(appDb);
				
				int Severity = iEFTFileDtlUpExt.EFTFileDtlUpSp(FileName,
				                                               Sequence,
				                                               BankRecon,
				                                               ref Infobar);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable EFTMappedPivotFieldsSp(string FileName,
		string ChildSequence,
		string Status,
		string RefType,
		string RefObject,
		string FilterString,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEFTMappedPivotFieldsExt = new EFTMappedPivotFieldsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEFTMappedPivotFieldsExt.EFTMappedPivotFieldsSp(FileName,
				ChildSequence,
				Status,
				RefType,
				RefObject,
				FilterString,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}
	}
}
