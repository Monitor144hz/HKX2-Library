using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkpPhantom Signatire: 0x9b7e6f86 size: 240 flags: FLAGS_NONE

    // m_overlapListeners m_class:  Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 208 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_phantomListeners m_class:  Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 224 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkpPhantom : hkpWorldObject, IEquatable<hkpPhantom?>
    {
        public IList<object> m_overlapListeners { set; get; } = Array.Empty<object>();
        public IList<object> m_phantomListeners { set; get; } = Array.Empty<object>();

        public override uint Signature { set; get; } = 0x9b7e6f86;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            des.ReadEmptyArray(br);
            des.ReadEmptyArray(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteVoidArray(bw);
            s.WriteVoidArray(bw);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteSerializeIgnored(xe, nameof(m_overlapListeners));
            xs.WriteSerializeIgnored(xe, nameof(m_phantomListeners));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkpPhantom);
        }

        public bool Equals(hkpPhantom? other)
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

