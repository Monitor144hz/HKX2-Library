using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkpShapeCollectionFilter Signatire: 0xe0708a00 size: 8 flags: FLAGS_NONE


    public partial class hkpShapeCollectionFilter : IHavokObject, IEquatable<hkpShapeCollectionFilter?>
    {
        private byte[] unk0 = new byte[8];

        public virtual uint Signature { set; get; } = 0xe0708a00;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            unk0 = br.ReadBytes(8);
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            bw.WriteBytes(unk0);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {

        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {

        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkpShapeCollectionFilter);
        }

        public bool Equals(hkpShapeCollectionFilter? other)
        {
            return other is not null &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();

            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

