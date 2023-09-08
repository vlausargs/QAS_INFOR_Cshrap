//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomVerifyFromInputsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomVerifyFromInputsFactory
	{
		public ICopyBomVerifyFromInputs Create(IApplicationDB appDB)
		{
			var _CopyBomVerifyFromInputs = new Production.CopyBomVerifyFromInputs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomVerifyFromInputsExt = timerfactory.Create<Production.ICopyBomVerifyFromInputs>(_CopyBomVerifyFromInputs);
			
			return iCopyBomVerifyFromInputsExt;
		}
	}
}
