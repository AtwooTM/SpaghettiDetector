﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;

namespace SpaghettiDetector.Test
{
    [TestFixture]
    class MethodBodyTests : TestBase
    {
        [Test]
        public void DetectVariableInMethodBody()
        {
            var n = GetNode("TestClassMethod");
            Assert.That(n.Dependencies.Where(x => x.TypeName.EndsWith("TestClassA")).Count() > 0);
        }

        [Test]
        public void DetectUnassignedVariableInMethodBody()
        {
            var n = GetNode("TestClassMethod2");
            Assert.That(n.Dependencies.Where(x => x.TypeName.EndsWith("TestClassMethod")).Count() > 0);
        }
    }

    #region Test Classes

    class TestClassMethod
    {
        public string Foo()
        {
            TestClassA a = new TestClassA();
            return "Foo";
        }
    }

    class TestClassMethod2
    {
        void Bar()
        {
            string result = (new TestClassMethod()).Foo();
        }
    }

    #endregion
}
