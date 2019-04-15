using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using pantherkitty.unity.scenedump;

namespace pantherkitty.unity.scenedump.example {
	public class ExampleRenderableClass {
		public void dumpToXml(XmlElement e) {
			XmlElement child = e.OwnerDocument.CreateElement(e.Prefix, "value", e.NamespaceURI);
			e.AppendChild(child);
			child.SetAttribute("name", "someValue");
			child.SetAttribute("type", "String");
			child.InnerText = ("meaningless value");


			child = e.OwnerDocument.CreateElement(e.Prefix, "value", e.NamespaceURI);
			e.AppendChild(child);
			child.SetAttribute("name", "min");
			child.SetAttribute("type", "System.Int32");
			child.InnerText = ("17");

			child = e.OwnerDocument.CreateElement(e.Prefix, "value", e.NamespaceURI);
			e.AppendChild(child);
			child.SetAttribute("name", "max");
			child.SetAttribute("type", "System.Int32");
			child.InnerText = "42";
		}
	}
}
