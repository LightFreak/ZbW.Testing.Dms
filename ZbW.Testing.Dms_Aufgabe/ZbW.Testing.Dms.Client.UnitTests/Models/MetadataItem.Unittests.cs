using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;


namespace ZbW.Testing.Dms.UnitTests.Models
{
    [TestFixture]
    class MetadataItemUnittests
    {
        private const string INVALID_String = "";
        private const string VALID_String = "This is it.";

        private static readonly DateTime INVALID_Date = new DateTime();
        private static readonly DateTime VALID_Date = new DateTime(11 / 09 / 2018);

        //private static readonly DateTime? INVALID_Date? = new DateTime?();
        //private static readonly DateTime? VALID_Date? = new DateTime?(11 / 09 / 2018);

        private const bool INVALID_BOOL = false;
        private const bool VALID_BOOL = true;

        [Test]
        public void MetadataItem_setPropertyBenutzer_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Benutzer = VALID_String;

            ////Assert
            Assert.AreEqual(m.Benutzer,VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyBezeichnung_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Bezeichnung = VALID_String;

            ////Assert
            Assert.AreEqual(m.Bezeichnung, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyErfassungsdatum_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Erfassungsdatum = VALID_Date;

            ////Assert
            Assert.AreEqual(m.Erfassungsdatum, VALID_Date);
        }

        [Test]
        public void MetadataItem_setPropertyOriginalPath_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.OriginalPath = VALID_String;

            ////Assert
            Assert.AreEqual(m.OriginalPath, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyFilename_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Filename = VALID_String;

            ////Assert
            Assert.AreEqual(m.Filename, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyExtension_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Extension = VALID_String;

            ////Assert
            Assert.AreEqual(m.Extension, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyDestination_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Destination = VALID_String;

            ////Assert
            Assert.AreEqual(m.Destination, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyIsRemoveFileEnable_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.IsRemoveFileEnable = VALID_BOOL;

            ////Assert
            Assert.AreEqual(m.IsRemoveFileEnable, VALID_BOOL);
        }

        [Test]
        public void MetadataItem_setPropertySelectedTypItem_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.SelectedTypItem = VALID_String;

            ////Assert
            Assert.AreEqual(m.SelectedTypItem, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyStichwoerter_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.Stichwoerter = VALID_String;

            ////Assert
            Assert.AreEqual(m.Stichwoerter, VALID_String);
        }

        [Test]
        public void MetadataItem_setPropertyValutaDatum_isValid()
        {
            //Arrange
            MetadataItem m = new MetadataItem(INVALID_String, INVALID_String, INVALID_Date, INVALID_String, INVALID_String, INVALID_String, INVALID_String, INVALID_BOOL, INVALID_String, INVALID_String, INVALID_Date);

            //Act
            m.ValutaDatum = VALID_Date;

            ////Assert
            Assert.AreEqual(m.ValutaDatum, VALID_Date);
        }
    }
}
