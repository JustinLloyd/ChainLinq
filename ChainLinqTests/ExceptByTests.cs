using System.Collections.Generic;
using System.Linq;
using ChainLinq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainLinqTests
{
    [TestClass]
    public class ExceptByTests
    {
        List<string> siblings = new List<string>()
        {
            "Kevyn",
            "Gail",
            "Robert",
            "Paul",
            "Christopher",
            "Gareth",
            "Nicholas",
            "Amanda",
            "Catherine",
            "Justin"
        };

        List<string> sisters = new List<string>()
        {
            "Gail",
            "Amanda",
            "Catherine"
        };

        private List<string> brothers = new List<string>()
        {
            "Kevyn",
            "Robert",
            "Paul",
            "Christopher",
            "Gareth",
            "Nicholas",
            "Justin"
        };

        [TestMethod]
        public void SiblingsExcludingSistersSimple()
        {
            List<string> result = siblings.ExceptBy(sisters, n => n).ToList();
            CollectionAssert.AreEquivalent(brothers, result);
        }
    }
}
