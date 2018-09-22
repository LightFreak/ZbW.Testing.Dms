using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Interfaces;
using ZbW.Testing.Dms.Client.Model;


namespace ZbW.Testing.Dms.Client.Provider
{
  public class XmlService : IXmlService
  {
    public void MetadataItemToXml(MetadataItem metadataItem, string targetDir) { 
    var xmlSerializer = new XmlSerializer(typeof(MetadataItem));

    var streamWriter = new StreamWriter(Path.Combine(targetDir, metadataItem.MetaDataFileName));
    xmlSerializer.Serialize(streamWriter, metadataItem);
    streamWriter.Flush();
    streamWriter.Close();

    //File.Copy(metadataItem.OriginalPath, Path.Combine(targetDir, metadataItem.Filename));
    
  }

    public IList<MetadataItem> XmlToMetadataItems(IList<string> metadataFile)
    {
      List<MetadataItem> metadataItemList = new List<MetadataItem>();
      foreach (var m in metadataFile)
      {
        var xmlSerializer = new XmlSerializer(typeof(MetadataItem));
        var streamReader = new StreamReader(m);
        MetadataItem metadata = (MetadataItem)xmlSerializer.Deserialize(streamReader);
        metadataItemList.Add(metadata);
      }

      return metadataItemList;
    }
  }
}
