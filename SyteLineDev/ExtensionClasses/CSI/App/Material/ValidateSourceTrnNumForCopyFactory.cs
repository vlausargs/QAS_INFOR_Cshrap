//PROJECT NAME: Material
//CLASS NAME: ValidateSourceTrnNumForCopyFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ValidateSourceTrnNumForCopyFactory
	{
		public IValidateSourceTrnNumForCopy Create(IApplicationDB appDB)
		{
			var _ValidateSourceTrnNumForCopy = new Material.ValidateSourceTrnNumForCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateSourceTrnNumForCopyExt = timerfactory.Create<Material.IValidateSourceTrnNumForCopy>(_ValidateSourceTrnNumForCopy);
			
			return iValidateSourceTrnNumForCopyExt;
		}
	}
}
