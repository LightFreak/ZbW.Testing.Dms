using FakeItEasy;
using NUnit.Framework;

using ZbW.Testing.Dms.Client.Interfaces;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Provider;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.UnitTests.Service
{
    [TestFixture]
    class FileOpUnitTests
    {
        private const string VALID_Path= @"D:\ZbW\4_Semester\Software\Testz.zip";
        private const string VALID_Filename = "Testz";
        private const string VALID_Extension = "zip";
        private const string VALID_Year = "2000";

        private const string INVALID_Path = "";
        private const string INVALID_Filename = "";
        private const string INVALID_Extension = "";
        private const string INVALID_Year = "";

        private  MetadataItem meta1;


        [Test]
        public void GenerateFilename_Default_CallNewGuidCorrect()
        {
            // arrange
            var fileOp = new FileOp();
            var fngServiceMock = A.Fake<FileNameGenerator>();
            fileOp.Guid = fngServiceMock;

            // act
            fileOp.GenerateFilename(VALID_Filename,VALID_Extension);

            // assert
            A.CallTo(() => fngServiceMock.NewGuid()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void GenerateFilename_Returns_ValidFilename()
        {
            //Arrange
            FileOp f= new FileOp();
            var sampleGuid = "6a715354-534b-47e1-9df3-2f77d0128040";
            var fileNameGeneratorStub = A.Fake<FileNameGenerator>();
            f.Guid = fileNameGeneratorStub;
            A.CallTo(() => fileNameGeneratorStub.NewGuid()).Returns(sampleGuid);
            
            //Act
            string[] result = new string[2];
            result = f.GenerateFilename(VALID_Filename,VALID_Extension);

            //Assert
            string[] expectedResult = new string[2];
            expectedResult[0] = $"{sampleGuid}_{VALID_Filename}_Content.{VALID_Extension}";
            expectedResult[1] = $"{sampleGuid}_{VALID_Filename}_Metadata.xml";
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GenerateFileName_Returns_InValidFilename()
        {
            //Arrange
            FileOp f = new FileOp();
            var sampleGuid = "6a715354-534b-47e1-9df3-2f77d0128040";
            var fileNameGeneratorStub = A.Fake<IFileNameGenerator>();
            A.CallTo(() => fileNameGeneratorStub.NewGuid()).Returns($"{sampleGuid}{INVALID_Filename}.{INVALID_Extension}");

            //Act
            var result = fileNameGeneratorStub.NewGuid();

            //Assert
            var expectedResult = $"{sampleGuid}{INVALID_Filename}.{INVALID_Extension}";
            Assert.AreEqual(result, expectedResult);
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

        [Test]
        public void SetDestinationDir_Default_AddingSucessfull()
        {
            // arrange
            var file = new FileOp();
            var fileServiceStub = A.Fake<FileServices>();
            A.CallTo(() => fileServiceStub.DestinationDir(VALID_Year,VALID_Path)).Returns(true);
            file.Destiny = fileServiceStub;


            // act
            file.SetDestinationDir(VALID_Year,VALID_Path);

            // assert
            Assert.That(file.ExtractFolderList().Count,Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void SetDestinationDir_CallsFileservice_Correct()
        {
            // arrange
            var file = new FileOp();
            var fileServiceMock = A.Fake<FileServices>();
            file.Destiny = fileServiceMock;

            // act
            file.SetDestinationDir(VALID_Year,VALID_Path);

            // assert
            A.CallTo(() => fileServiceMock.DestinationDir(VALID_Year, VALID_Path)).MustHaveHappenedOnceExactly();
        }
        

       

    }
}
