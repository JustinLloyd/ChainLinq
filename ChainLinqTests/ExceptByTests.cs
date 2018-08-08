using System;
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

        class Sibling
        {
            public string Name;
            public DateTime Birthdate;
        }

        private List<Sibling> siblingsComplex = new List<Sibling>
        {
            new Sibling(){Name="Kevyn", Birthdate = new DateTime(1940,4,1)},
            new Sibling(){Name="Gail", Birthdate = new DateTime(1940,6,1)},
            new Sibling(){Name="Robert", Birthdate = new DateTime(1940,7,1)},
            new Sibling(){Name="Paul", Birthdate = new DateTime(1950,10,1)},
            new Sibling(){Name="Christopher", Birthdate = new DateTime(1950,1,1)},
            new Sibling(){Name="Gareth", Birthdate = new DateTime(1950,3,1)},
            new Sibling(){Name="Nicholas", Birthdate = new DateTime(1950,6,1)},
            new Sibling(){Name="Amanda", Birthdate = new DateTime(1960,4,1)},
            new Sibling(){Name="Catherine", Birthdate = new DateTime(1960,2,1)},
            new Sibling(){Name="Justin", Birthdate = new DateTime(1960,4,1)},
        };

        private List<Sibling> brothersComplex = new List<Sibling>
        {
            new Sibling(){Name="Kevyn", Birthdate = new DateTime(1940,4,1)},
            new Sibling(){Name="Robert", Birthdate = new DateTime(1940,7,1)},
            new Sibling(){Name="Paul", Birthdate = new DateTime(1950,10,1)},
            new Sibling(){Name="Christopher", Birthdate = new DateTime(1950,1,1)},
            new Sibling(){Name="Gareth", Birthdate = new DateTime(1950,3,1)},
            new Sibling(){Name="Nicholas", Birthdate = new DateTime(1950,6,1)},
            new Sibling(){Name="Justin", Birthdate = new DateTime(1960,4,1)},
        };

        private List<Sibling> sistersComplex = new List<Sibling>
        {
            new Sibling(){Name="Gail", Birthdate = new DateTime(1940,6,1)},
            new Sibling(){Name="Amanda", Birthdate = new DateTime(1960,4,1)},
            new Sibling(){Name="Catherine", Birthdate = new DateTime(1960,2,1)},
        };

        [TestMethod]
        public void SiblingsExcludingSistersSimple()
        {
            List<string> result = siblings.ExceptBy(sisters, n => n).ToList();
            CollectionAssert.AreEquivalent(brothers, result);
        }

        [TestMethod]
        public void SiblingsExcludingBrothersComplexType()
        {
            List<Sibling> result = siblingsComplex.ExceptBy(brothersComplex, n => n.Name).ToList();
            CollectionAssert.AreEqual(sistersComplex, result, new SiblingComparer());
        }

        private class SiblingComparer : Comparer<Sibling>
        {
            public override int Compare(Sibling x, Sibling y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
