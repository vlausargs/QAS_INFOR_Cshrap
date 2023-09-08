//PROJECT NAME: FinanceExt
//CLASS NAME: SLAllDimensionWithAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLAllDimensionWithAttributes")]
	public class SLAllDimensionWithAttributes : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteDimensionSp(string ObjectName,
			string Dimension)
		{
			var iDeleteDimensionExt = new DeleteDimensionFactory().Create(this, true);
			
			var result = iDeleteDimensionExt.DeleteDimensionSp(ObjectName,
				Dimension);
			
			return result??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateDimAndDimAttributesSp(int? Selected,
		string ObjectName,
		string Attribute,
		string DimName,
		string DimDescription,
		int? Required)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateDimAndDimAttributesExt = new UpdateDimAndDimAttributesFactory().Create(appDb);
				
				var result = iUpdateDimAndDimAttributesExt.UpdateDimAndDimAttributesSp(Selected,
				ObjectName,
				Attribute,
				DimName,
				DimDescription,
				Required);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
