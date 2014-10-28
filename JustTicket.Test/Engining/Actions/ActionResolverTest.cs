using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JustTicket.Engining;
using JustTicket.Engining.Actions;

namespace JustTicket.Test.Engining.Actions
{
    [TestFixture]
    public class ActionResolverTest
    {
        [Test]
        public void ResolveAction()
        {
            string actionName = "Assignment";
            string ns = "";
            JustTicket.Engining.Actions.Action action = ActionResolver.ResolveAction(actionName,ns);
            Assert.IsNotNull(action);
        }

    }
}
