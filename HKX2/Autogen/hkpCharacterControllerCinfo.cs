using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkpCharacterControllerCinfo Signatire: 0xda8c7d7d size: 16 flags: FLAGS_NONE


    public partial class hkpCharacterControllerCinfo : hkReferencedObject, IEquatable<hkpCharacterControllerCinfo?>
    {


        public override uint Signature { set; get; } = 0xda8c7d7d;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkpCharacterControllerCinfo);
        }

        public bool Equals(hkpCharacterControllerCinfo? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(base.GetHashCode());
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

