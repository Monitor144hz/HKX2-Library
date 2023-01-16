using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkpThinBoxMotion Signatire: 0x64abf85c size: 320 flags: FLAGS_NONE


    public partial class hkpThinBoxMotion : hkpBoxMotion, IEquatable<hkpThinBoxMotion?>
    {


        public override uint Signature => 0x64abf85c;

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
            return Equals(obj as hkpThinBoxMotion);
        }

        public bool Equals(hkpThinBoxMotion? other)
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

