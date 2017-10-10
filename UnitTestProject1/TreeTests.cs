﻿using System;
using NUnit.Framework;
using TreeCollections;

namespace UnitTestProject1
{
    [TestFixture(typeof(BsTree))]
    [TestFixture(typeof(BsTreeR))]
    [TestFixture(typeof(BsTreeLink))]
    public class NUnitTests<TTree> where TTree : ITree, new()
    {
        ITree lst = new TTree();

        [SetUp]
        public void SetUp()
        {
            lst.Clear();
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 6 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 1, 3, 4, 7, 9 })]
        public void TestToArray(int[] input, int[] res)
        {
            lst.Init(input);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 6 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 1, 3, 4, 7, 9 })]
        public void TestInit(int[] input, int[] res)
        {
            lst.Init(input);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, "")]
        [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 2 }, "2")]
        [TestCase(new int[] { 5, 6 }, "5, 6")]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, "1, 3, 4, 7, 9")]
        public void TestToString(int[] input, string res)
        {
            lst.Init(input);
            Assert.AreEqual(res, lst.ToString());
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestSize(int[] input, int res)
        {
            lst.Init(input);
            Assert.AreEqual(res, lst.Size());
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1, 12, 2, -5, 5 }, 4)]
        public void TestHeight(int[] input, int res)
        {
            lst.Init(input);
            Assert.AreEqual(res, lst.Height());
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, 1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1, 12, 2, -5, 5 }, 4)]
        public void TestWidth(int[] input, int res)
        {
            lst.Init(input);
            Assert.AreEqual(res, lst.Width());
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 5, 6 }, 1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1, 12, 2, -5, 5 }, 5)]
        public void TestNodes(int[] input, int res)
        {
            lst.Init(input);
            Assert.AreEqual(res, lst.Nodes());
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, 1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 3)]
        public void TestLeaves(int[] input, int res)
        {
            lst.Init(input);
            Assert.AreEqual(res, lst.Leaves());
        }

        [Test]
        [TestCase(null, new int[] { 1 }, 1)]
        [TestCase(new int[] { }, new int[] {2 }, 2)]
        [TestCase(new int[] { 2 }, new int[] {0, 2 }, 0)]
        [TestCase(new int[] { 5, 8 }, new int[] { 5, 6 ,8}, 6)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 0, 1, 3, 4, 7, 9 }, 0)]
        public void TestAdd(int[] input, int[] res, int val)
        {
            lst.Init(input);
            lst.Add(val);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 5, 8 }, new int[] { 8, 5 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 9,7,4,3,1})]
        [TestCase(new int[] { 3, 7, 4, 9, 1, 12, 2, -5, 5 }, new int[] { 12,9,7,5,4,3,2,1,-5 })]
        public void TestReverse(int[] input, int[] res)
        {
            lst.Init(input);
            lst.Reverse();
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { })]
        [TestCase(new int[] { 5, 6 }, new int[] { })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { })]
        public void TestClear(int[] input, int[] res)
        {
            lst.Init(input);
            lst.Clear();
            CollectionAssert.AreEqual(res, lst.ToArray());
        }



        //Test DelRightReplace

        [Test]
        [TestCase(new int[] { 2 }, new int[] { }, 2)]
        [TestCase(new int[] { 5, 8 }, new int[] { 5 }, 8)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 9, 8 }, 2)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 2, 8 }, 9)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 1, 0, 8, 2, 9 }, 7)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 7, 1, 9, 0, 2, 8 }, 3)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 2, 7, 0, 9, 8 }, 1)]
        public void TestDelRightReplace(int[] input, int[] res, int val)
        {
            TTree compare = new TTree();
            compare.Init(res);
            lst.Init(input);
            lst.DelRightReplace(val);
            Assert.IsTrue(lst.Equal(compare));
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelRightReplaceEx(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelRightReplace(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelRightReplaceExEmppty(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelRightReplace(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }


        [Test]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestDelRightReplaceExNull(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<ValueNotFoundEx>(() => lst.DelRightReplace(val));
            Assert.AreEqual(typeof(ValueNotFoundEx), ex.GetType());
        }




        //Test DelLeftReplace

        [Test]
        [TestCase(new int[] { 2 }, new int[] { }, 2)]
        [TestCase(new int[] { 5, 8 }, new int[] { 5 }, 8)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 9, 8 }, 2)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 2, 8 }, 9)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 1, 0, 9, 2, 8 }, 7)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 2, 1, 7, 9, 0, 8 }, 3)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 0, 2, 7, 9, 8 }, 1)]
        public void TestDelLeftReplace(int[] input, int[] res, int val)
        {
            TTree compare = new TTree();
            compare.Init(res);
            lst.Init(input);
            lst.DelLeftReplace(val);
            Assert.IsTrue(lst.Equal(compare));
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelLeftReplaceEx(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelLeftReplace(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelLeftReplaceExEmppty(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelLeftReplace(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }


        [Test]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestDelLeftReplaceExNull(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<ValueNotFoundEx>(() => lst.DelLeftReplace(val));
            Assert.AreEqual(typeof(ValueNotFoundEx), ex.GetType());
        }



        //Test DelRightRotate

        [Test]
        [TestCase(new int[] { 2 }, new int[] { }, 2)]
        [TestCase(new int[] { 5, 8 }, new int[] { 5 }, 8)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 9, 8 }, 2)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 2, 8 }, 9)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 1, 0, 9, 2, 8 }, 7)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 1, 7, 0, 9, 2, 8 }, 3)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 0, 2, 7, 9, 8 }, 1)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8, 5, 6, 4 }, new int[] { 1, 7, 0, 9, 8, 5, 6, 4, 2 }, 3)]
        public void TestDelRightRotate(int[] input, int[] res, int val)
        {
            TTree compare = new TTree();
            compare.Init(res);
            lst.Init(input);
            lst.DelRightRotate(val);
            Assert.IsTrue(lst.Equal(compare));
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelRightRotateEx(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelRightRotate(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelRightRotateExEmppty(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelRightRotate(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }


        [Test]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestDelRightRotateExNull(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<ValueNotFoundEx>(() => lst.DelRightRotate(val));
            Assert.AreEqual(typeof(ValueNotFoundEx), ex.GetType());
        }

        //Test DelLeftRotate

        [Test]
        [TestCase(new int[] { 2 }, new int[] { }, 2)]
        [TestCase(new int[] { 5, 8 }, new int[] { 5 }, 8)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 9, 8 }, 2)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 7, 1, 0, 2, 8 }, 9)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 1, 0, 9, 2, 8 }, 7)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 7, 1, 0, 9, 2, 8 }, 3)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8 }, new int[] { 3, 2, 0, 7, 9, 8 }, 1)]
        [TestCase(new int[] { 3, 7, 1, 0, 9, 2, 8, 5, 6, 4 }, new int[] { 7, 1, 0, 9, 8, 2, 5, 4, 6 }, 3)]
        public void TestDelLeftRotate(int[] input, int[] res, int val)
        {
            TTree compare = new TTree();
            compare.Init(res);
            lst.Init(input);
            lst.DelLeftRotate(val);
            Assert.IsTrue(lst.Equal(compare));
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelLeftRotateEx(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelLeftRotate(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }

        [Test]
        [TestCase(null, 5)]
        [TestCase(new int[] { }, 2)]
        public void TestDelLeftRotateExEmppty(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyTreeEx>(() => lst.DelLeftRotate(val));
            Assert.AreEqual(typeof(EmptyTreeEx), ex.GetType());
        }


        [Test]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestDelLeftRotateExNull(int[] input, int val)
        {
            lst.Init(input);
            var ex = Assert.Throws<ValueNotFoundEx>(() => lst.DelLeftRotate(val));
            Assert.AreEqual(typeof(ValueNotFoundEx), ex.GetType());
        }
    }
}
