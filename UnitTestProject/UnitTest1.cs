using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Quadratic_equation;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public double[] actual, right;
        Form1 form = new Form1();
        Calculation calc = new Calculation();
        [TestMethod]
        public void pos_descriminant()
        {
            actual = form.calc(1, 4, -5);
            right = new double[] {1, -5};
            CollectionAssert.AreEqual(right, actual);
        }
        [TestMethod]
        public void neg_descriminant()
        {
            actual = form.calc(1, -5, 7);
            right = new double[] {Convert.ToDouble(null), Convert.ToDouble(null)};
            CollectionAssert.AreEqual(right, actual);
        }
        [TestMethod]
        public void zero_descriminant()
        {
            actual = form.calc(1, -10, 25);
            right = new double[] { 5, 5 };
            CollectionAssert.AreEqual(right, actual);
        }
        [TestMethod]
        public void pos_descriminant_separate_class()
        {
            actual = calc.calculation(1, -70, 600);
            right = new double[] { 60, 10 };
            CollectionAssert.AreEqual(right, actual);
        }
        [TestMethod]
        public void neg_descriminant_separate_class()
        {
            actual = calc.calculation(2, -1, 3.5);
            right = new double[] { Convert.ToDouble(null), Convert.ToDouble(null) };
            CollectionAssert.AreEqual(right, actual);
        }
        [TestMethod]
        public void zero_descriminant_separate_class()
        {
            actual = calc.calculation(3, -18, 27);
            right = new double[] { 3, 3 };
            CollectionAssert.AreEqual(right, actual);
        }
    }
}
