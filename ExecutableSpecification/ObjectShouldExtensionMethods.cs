using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExecutableSpecification
{
    public static class ObjectShouldExtensionMethods
    {
        public static void ShouldBeTrue(this bool o)
        {
            Assert.IsTrue(o);
        }

        public static void ShouldBeFalse(this bool o)
        {
            Assert.IsFalse(o);
        }

        public static void ShouldEqual<T>(this T o, T expected)
        {
            Assert.AreEqual<T>(expected, o);
        }

        public static void ShouldBeLessThan<T>(this T o, T expected) where T : IComparable
        {
            Assert.IsTrue(o.CompareTo(expected) < 0);
        }
    }
}
