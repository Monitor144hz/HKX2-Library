using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkpHeightFieldShape Signatire: 0xe7eca7eb size: 32 flags: FLAGS_NONE


    public partial class hkpHeightFieldShape : hkpShape, IEquatable<hkpHeightFieldShape?>
    {


        public override uint Signature => 0xe7eca7eb;

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
            return Equals(obj as hkpHeightFieldShape);
        }

        public bool Equals(hkpHeightFieldShape? other)
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

