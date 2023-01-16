using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkMemoryTrackerAttribute Signatire: 0x7bd5c66f size: 1 flags: FLAGS_NONE


    public partial class hkMemoryTrackerAttribute : IHavokObject, IEquatable<hkMemoryTrackerAttribute?>
    {
        private byte[] unk0 = new byte[1];

        public virtual uint Signature => 0x7bd5c66f;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            unk0 = br.ReadBytes(1);
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
            return Equals(obj as hkMemoryTrackerAttribute);
        }

        public bool Equals(hkMemoryTrackerAttribute? other)
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

