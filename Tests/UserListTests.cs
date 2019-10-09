using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVP.DomainModel;
using System.IO;

namespace Tests
{
    [TestFixture]
    class UserListTests
    {
        UserList _userList;

        [SetUp]
        public void SetUp()
        {
            _userList = new UserList("test");
        }

        [Test]
        public void AddUser_Has2Items()
        {
            //Arrange
            User expected = new User()
            {
                Name = "Ivan"
            };

            //Act
            _userList.Add("Ivan");

            //Assert
            Assert.That(_userList.Data(), Has.Exactly(2).Items);
        }

        [Test]
        public void FindAdmin()
        {
            //Arrange
            User expected = new User()
            {
                Name = "ADMIN"
            };

            //Act
            User admin = _userList.Find("ADMIN");

            //Assert
            Assert.AreEqual(expected.Name, admin.Name);
            Assert.AreEqual(expected.Password, admin.Password);
            Assert.AreEqual(expected.Blocked, admin.Blocked);
            Assert.AreEqual(expected.Limited, admin.Limited);
        }

        [Test]
        public void FindNotExistedUser_nullReturned()
        {

            //Act
            User NotExistedUser = _userList.Find("qwe");

            //Assert
            Assert.That(NotExistedUser, Is.EqualTo(null));
        }


        [Test]
        public void Save_fileCreate()
        {
            // Act
            _userList.Save();
            //Assert
            Assert.That(new FileInfo("test.xml"), Does.Exist);
        }
    }
}
