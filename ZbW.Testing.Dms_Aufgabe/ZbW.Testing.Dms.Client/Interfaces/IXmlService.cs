using System.Collections.Generic;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Interfaces
{
  public interface IXmlService
  {
    void MetadataItemToXml(MetadataItem metadataItem, string targetDir);

    IList<MetadataItem> XmlToMetadataItems(IList<string> metadataFile);
  }
}