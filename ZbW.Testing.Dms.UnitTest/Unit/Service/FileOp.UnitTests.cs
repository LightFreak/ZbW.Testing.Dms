using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Fakes;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.UnitTests.Service
{
    [TestFixture]
    class FileOpUnitTests
    {
        private const string VALID_Path= @"D:\ZbW\4_Semester\Software\Testz.zip";
        private const string VALID_Filename = "Testz";
        private const string VALID_Extension = "zip";

        private const string INVALID_Path = "";
        private const string INVALID_Filename = "";
        private const string INVALID_Extension = "";

        [Test]
        public void GenerateFileNAme_Returns_ValidFilename()
        {
            //Arrange
            FileOp f= new FileOp();
            var sampleGuid = "6a715354-534b-47e1-9df3-2f77d0128040";
            
            var fileNameGeneratorStub = new FileNameGeneratorStub(sampleGuid);
            //Act
            var result = f.GenerateFilename(fileNameGeneratorStub,VALID_Filename);

            //Assert
            var expectedResult = $"{sampleGuid}{VALID_Filename}";
            Assert.AreEqual(result,expectedResult);
        }

        [Test]
        public void GetFilename_Returns_ValidFilename()
        {
            //Arrange
            FileOp f = new FileOp();

            //Act
            var result = f.GetFilename(VALID_Path);

            //Assert
            Assert.AreEqual(result,VALID_Filename);
        }

        [Test]
        public void GetExtension_Returns_ValidExtension()
        {
            //Arrange
            FileOp f = new FileOp();

            //Act
            var result = f.GetExtension(VALID_Path);

            //Assert
            Assert.AreEqual(result, VALID_Extension);
        }

        [Test]
        public void GenerateFileNAme_Returns_InValidFilename()
        {
            //Arrange
            FileOp f = new FileOp();
            var sampleGuid = "6a715354-534b-47e1-9df3-2f77d0128040";

            var fileNameGeneratorStub = new FileNameGeneratorStub(sampleGuid);
            //Act
            var result = f.GenerateFilename(fileNameGeneratorStub, INVALID_Filename);

            //Assert
            var expectedResult = $"{sampleGuid}{INVALID_Filename}";
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void GetFilename_Returns_INValidFilename()
        {
            //Arrange
            FileOp f = new FileOp();

            //Act
            var result = f.GetFilename(INVALID_Path);

            //Assert
            Assert.AreEqual(result, INVALID_Filename);
        }

        [Test]
        public void GetExtension_Returns_INValidExtension()
        {
            //Arrange
            FileOp f = new FileOp();

            //Act
            var result = f.GetExtension(INVALID_Path);

            //Assert
            Assert.AreEqual(result, INVALID_Extension);
        }

        //[Test]
        //public void MoveFile_Returns_ValidFilename()
        //{
        //    //Arrange
        //    FileOp f = new FileOp();

        //    //Act
        //    var result = f.GetFilename(VALID_Path);

        //    //Assert
        //    Assert.AreEqual(result, VALID_Filename);
        //}

        //[Test]
        //public void GetFilename_Returns_ValidFilename()
        //{
        //    //Arrange
        //    FileOp f = new FileOp();

        //    //Act
        //    var result = f.GetFilename(VALID_Path);

        //    //Assert
        //    Assert.AreEqual(result, VALID_Filename);
        //}
    }
}
