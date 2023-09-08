//PROJECT NAME: MaterialExt
//CLASS NAME: SLAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLAttributes")]
	public class SLAttributes : CSIExtensionClassBase, IExtFTSLAttributes
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_AttributeValueSp(Guid? RowPointer,
		string AttrGroup,
		string AttrGroupClass,
		[Optional] string FilterString)
		{
			var iCLM_AttributeValueExt = new CLM_AttributeValueFactory().Create(this, true);
			
			var result = iCLM_AttributeValueExt.CLM_AttributeValueSp(RowPointer,
			AttrGroup,
			AttrGroupClass,
			FilterString);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateOverrideForAttributesExt = new UpdateOverrideForAttributesFactory().Create(appDb);
				
				var result = iUpdateOverrideForAttributesExt.UpdateOverrideForAttributesSp(ValColName,
				Value,
				Type,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RefRowPointer,
		ref Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertOverrideForAttributesExt = new InsertOverrideForAttributesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertOverrideForAttributesExt.InsertOverrideForAttributesSp(ValColName,
				Value,
				Type,
				RefRowPointer,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
