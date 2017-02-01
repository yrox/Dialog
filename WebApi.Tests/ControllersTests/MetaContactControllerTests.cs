﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Entities;
using DTOs;
using Moq;
using NUnit.Framework;
using Olga.Data;
using WebApi.Controllers;

namespace WebApi.Tests.ControllersTests
{
    [TestFixture]
    public class BaseEntityControllerTests
    {
        private Mock<UnitOfWork> _unitOfWorkMock;
        private MetaContactController _metaContactController;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(x => x.AddProfile<MapProfile>());

            _unitOfWorkMock = new Mock<UnitOfWork>();
            _unitOfWorkMock.Setup(x => x.Repository<MetaContact>()).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<MetaContact>().Find(It.IsAny<int>())).Returns(new MetaContact());
            _unitOfWorkMock.Setup(x => x.Repository<MetaContact>().Delete(It.IsAny<MetaContact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<MetaContact>().Insert(It.IsAny<MetaContact>())).Verifiable();
            _unitOfWorkMock.Setup(x => x.Repository<MetaContact>().Update(It.IsAny<MetaContact>())).Verifiable();

            _metaContactController = new MetaContactController(_unitOfWorkMock.Object);
        }

        [Test]
        public void Get_ShoudReturnEntity_Succeed()
        {
            var result = _metaContactController.Get(1);
            _unitOfWorkMock.Verify(x => x.Repository<MetaContact>().Find(It.IsAny<int>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<MetaContactDTO>(result);
        }

        [Test]
        public void GetAll_ShouldReturnEntitiesCol_Succeed()
        {
            var result = _metaContactController.GetAll();
            _unitOfWorkMock.Verify(x => x.Repository<MetaContact>().GetAll(), Times.Once);
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<MetaContactDTO>>(result);
        }

        [Test]
        public void Insert_ShouldInsertEntity_Succeed()
        {
            _metaContactController.Insert(new MetaContactDTO());
            _unitOfWorkMock.Verify(x => x.Repository<MetaContact>(), Times.Once);
        }

        [Test]
        public void Update_ShouldUpdatetEntity_Succeed()
        {
            var id = new Random().Next();
            _metaContactController.Update(id, new MetaContactDTO {Id = id});
            _unitOfWorkMock.Verify(x => x.Repository<MetaContact>().Update(It.IsAny<MetaContact>()), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteEntity_Succeed()
        {
            _metaContactController.Delete(new MetaContactDTO());
            _unitOfWorkMock.Verify(x => x.Repository<MetaContact>().Delete(It.IsAny<MetaContact>()), Times.Once);
        }
    }
}
