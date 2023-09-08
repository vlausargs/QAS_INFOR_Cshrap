//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomVerifyToInputsFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomVerifyToInputsFactory
	{
		public ICopyBomVerifyToInputs Create(IApplicationDB appDB)
		{
			var _CopyBomVerifyToInputs = new Production.CopyBomVerifyToInputs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomVerifyToInputsExt = timerfactory.Create<Production.ICopyBomVerifyToInputs>(_CopyBomVerifyToInputs);
			
			return iCopyBomVerifyToInputsExt;
		}
	}
}
