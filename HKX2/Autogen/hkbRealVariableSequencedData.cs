using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HKX2
{
    // hkbRealVariableSequencedData Signatire: 0xe2862d02 size: 40 flags: FLAGS_NONE

    // m_samples m_class: hkbRealVariableSequencedDataSample Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_variableIndex m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    public partial class hkbRealVariableSequencedData : hkbSequencedData, IEquatable<hkbRealVariableSequencedData?>
    {
        public IList<hkbRealVariableSequencedDataSample> m_samples { set; get; } = Array.Empty<hkbRealVariableSequencedDataSample>();
        public int m_variableIndex { set; get; }

        public override uint Signature { set; get; } = 0xe2862d02;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_samples = des.ReadClassArray<hkbRealVariableSequencedDataSample>(br);
            m_variableIndex = br.ReadInt32();
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassArray(bw, m_samples);
            bw.WriteInt32(m_variableIndex);
            bw.Position += 4;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_samples = xd.ReadClassArray<hkbRealVariableSequencedDataSample>(xe, nameof(m_samples));
            m_variableIndex = xd.ReadInt32(xe, nameof(m_variableIndex));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassArray(xe, nameof(m_samples), m_samples);
            xs.WriteNumber(xe, nameof(m_variableIndex), m_variableIndex);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkbRealVariableSequencedData);
        }

        public bool Equals(hkbRealVariableSequencedData? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   m_samples.SequenceEqual(other.m_samples) &&
                   m_variableIndex.Equals(other.m_variableIndex) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(base.GetHashCode());
            hashcode.Add(m_samples.Aggregate(0, (x, y) => x ^ y?.GetHashCode() ?? 0));
            hashcode.Add(m_variableIndex);
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

