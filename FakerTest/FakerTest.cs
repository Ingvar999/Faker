using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTOLib;
using FakerLib;

namespace FakerTest
{
    [TestClass]
    public class FakerTest
    {
        private Faker faker;

        private class SimpleDTO : DTO
        {
            public int simpleField;
            public Enum unsuppotredField;
        }

        private class RecursiveDTO : DTO
        {
            public RecursiveDTO dto;
            public int simpleField;
        }

        private void Setup()
        {
            faker = new Faker();
        }

        [TestMethod]
        public void NotNullResult()
        {
            Setup();
            SimpleDTO obj = faker.Create<SimpleDTO>();
            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void NotDefaultField()
        {
            Setup();
            SimpleDTO obj = faker.Create<SimpleDTO>();
            Assert.AreNotEqual(obj.simpleField, 0);
        }

        [TestMethod]
        public void NotNullRecursiveField()
        {
            Setup();
            RecursiveDTO obj = faker.Create<RecursiveDTO>();
            Assert.AreNotEqual(obj.dto, 0);
        }
    }
}
