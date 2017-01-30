﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using NUnit.Framework;

namespace Data.Test.Entities
{
    public class ContactTests
    {
        private Contact _contact = new Contact();

        [Test]
        public void AccountId_ShouldGetSetValue_Succeed()
        {
            var id = new Random().Next();
            _contact.AccountId = id;
            Assert.AreEqual(id, _contact.AccountId);
        }

        [Test]
        public void Name_ShouldGetSetValue_Succeed()
        {
            const string name = "someName";
            _contact.Name = name;
            Assert.AreEqual(name, _contact.Name);
        }

        [Test]
        public void MetaContactId_ShouldGetSetValue_Succeed()
        {
            var id = new Random().Next();
            _contact.MetaContactId = id;
            Assert.NotNull(_contact.MetaContactId);
            Assert.AreEqual(id, _contact.MetaContactId);
        }

    }
}


