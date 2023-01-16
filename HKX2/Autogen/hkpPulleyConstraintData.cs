using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkpPulleyConstraintData Signatire: 0x972058ed size: 144 flags: FLAGS_NONE

    // m_atoms m_class: hkpPulleyConstraintDataAtoms Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 32 flags: ALIGN_16|FLAGS_NONE enum: 
    public partial class hkpPulleyConstraintData : hkpConstraintData, IEquatable<hkpPulleyConstraintData?>
    {
        public hkpPulleyConstraintDataAtoms m_atoms { set; get; } = new();

        public override uint Signature => 0x972058ed;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.Position += 8;
            m_atoms.Read(des, br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.Position += 8;
            m_atoms.Write(s, bw);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_atoms = xd.ReadClass<hkpPulleyConstraintDataAtoms>(xe, nameof(m_atoms));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClass<hkpPulleyConstraintDataAtoms>(xe, nameof(m_atoms), m_atoms);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkpPulleyConstraintData);
        }

        public bool Equals(hkpPulleyConstraintData? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   ((m_atoms is null && other.m_atoms is null) || (m_atoms is not null && other.m_atoms is not null && m_atoms.Equals((IHavokObject)other.m_atoms))) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(base.GetHashCode());
            hashcode.Add(m_atoms);
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

