using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbDampingModifierInternalState Signatire: 0x508d3b36 size: 80 flags: FLAGS_NONE

    // m_dampedVector m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_vecErrorSum m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_vecPreviousError m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 48 flags: FLAGS_NONE enum: 
    // m_dampedValue m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    // m_errorSum m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 68 flags: FLAGS_NONE enum: 
    // m_previousError m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 72 flags: FLAGS_NONE enum: 
    public partial class hkbDampingModifierInternalState : hkReferencedObject
    {
        public Vector4 m_dampedVector { set; get; } = default;
        public Vector4 m_vecErrorSum { set; get; } = default;
        public Vector4 m_vecPreviousError { set; get; } = default;
        public float m_dampedValue { set; get; } = default;
        public float m_errorSum { set; get; } = default;
        public float m_previousError { set; get; } = default;

        public override uint Signature => 0x508d3b36;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_dampedVector = br.ReadVector4();
            m_vecErrorSum = br.ReadVector4();
            m_vecPreviousError = br.ReadVector4();
            m_dampedValue = br.ReadSingle();
            m_errorSum = br.ReadSingle();
            m_previousError = br.ReadSingle();
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteVector4(m_dampedVector);
            bw.WriteVector4(m_vecErrorSum);
            bw.WriteVector4(m_vecPreviousError);
            bw.WriteSingle(m_dampedValue);
            bw.WriteSingle(m_errorSum);
            bw.WriteSingle(m_previousError);
            bw.Position += 4;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_dampedVector = xd.ReadVector4(xe, nameof(m_dampedVector));
            m_vecErrorSum = xd.ReadVector4(xe, nameof(m_vecErrorSum));
            m_vecPreviousError = xd.ReadVector4(xe, nameof(m_vecPreviousError));
            m_dampedValue = xd.ReadSingle(xe, nameof(m_dampedValue));
            m_errorSum = xd.ReadSingle(xe, nameof(m_errorSum));
            m_previousError = xd.ReadSingle(xe, nameof(m_previousError));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteVector4(xe, nameof(m_dampedVector), m_dampedVector);
            xs.WriteVector4(xe, nameof(m_vecErrorSum), m_vecErrorSum);
            xs.WriteVector4(xe, nameof(m_vecPreviousError), m_vecPreviousError);
            xs.WriteFloat(xe, nameof(m_dampedValue), m_dampedValue);
            xs.WriteFloat(xe, nameof(m_errorSum), m_errorSum);
            xs.WriteFloat(xe, nameof(m_previousError), m_previousError);
        }
    }
}

