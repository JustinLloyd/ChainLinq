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

        enum Gender
        {
            Male,
            Female,
        }

        class Sibling
        {
            public string Name;
            public DateTime Birthdate;
            public Gender Gender;
        }

        class Brother : Sibling
        {
            public Brother()
            {
                Gender = Gender.Male;
            }
        }

        class Sister : Sibling
        {
            public Sister()
            {
                Gender = Gender.Male;
            }

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

        private List<Sibling> genderedSiblingsComplex = new List<Sibling>
        {
            new Sibling(){Name="Kevyn", Birthdate = new DateTime(1940,4,1), Gender = Gender.Male},
            new Sibling(){Name="Gail", Birthdate = new DateTime(1940,6,1), Gender = Gender.Female},
            new Sibling(){Name="Robert", Birthdate = new DateTime(1940,7,1), Gender = Gender.Male},
            new Sibling(){Name="Paul", Birthdate = new DateTime(1950,10,1), Gender = Gender.Male},
            new Sibling(){Name="Christopher", Birthdate = new DateTime(1950,1,1), Gender = Gender.Male},
            new Sibling(){Name="Gareth", Birthdate = new DateTime(1950,3,1), Gender = Gender.Male},
            new Sibling(){Name="Nicholas", Birthdate = new DateTime(1950,6,1), Gender = Gender.Male},
            new Sibling(){Name="Amanda", Birthdate = new DateTime(1960,4,1), Gender = Gender.Female},
            new Sibling(){Name="Catherine", Birthdate = new DateTime(1960,2,1), Gender = Gender.Female},
            new Sibling(){Name="Justin", Birthdate = new DateTime(1960,4,1), Gender = Gender.Male},
        };

        private List<Brother> genderedBrothersComplex = new List<Brother>
        {
            new Brother(){Name="Kevyn", Birthdate = new DateTime(1940,4,1), Gender = Gender.Male},
            new Brother(){Name="Robert", Birthdate = new DateTime(1940,7,1), Gender = Gender.Male},
            new Brother(){Name="Paul", Birthdate = new DateTime(1950,10,1), Gender = Gender.Male},
            new Brother(){Name="Christopher", Birthdate = new DateTime(1950,1,1), Gender = Gender.Male},
            new Brother(){Name="Gareth", Birthdate = new DateTime(1950,3,1), Gender = Gender.Male},
            new Brother(){Name="Nicholas", Birthdate = new DateTime(1950,6,1), Gender = Gender.Male},
            new Brother(){Name="Justin", Birthdate = new DateTime(1960,4,1), Gender = Gender.Male},
        };

        private List<Sister> genderedSistersComplex = new List<Sister>
        {
            new Sister(){Name="Gail", Birthdate = new DateTime(1940,6,1), Gender = Gender.Female},
            new Sister(){Name="Amanda", Birthdate = new DateTime(1960,4,1), Gender = Gender.Female},
            new Sister(){Name="Catherine", Birthdate = new DateTime(1960,2,1), Gender = Gender.Female},
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

        [TestMethod]
        public void GenderedSiblingsExcludingSistersComplexType()
        {
            List<Sibling> result = genderedSiblingsComplex.ExceptBy(s => s.Name, genderedBrothersComplex, b=>b.Name).ToList();
            CollectionAssert.AreEqual(genderedSistersComplex, result, new SiblingComparer());
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
