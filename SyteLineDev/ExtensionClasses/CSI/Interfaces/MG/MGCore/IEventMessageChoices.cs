using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.CRUD;

namespace CSI.MG.MGCore
{
	public interface IEventMessageChoices
	{
		ICollectionLoadResponse EventMessageChoicesFn(string Choices);
	}
}
