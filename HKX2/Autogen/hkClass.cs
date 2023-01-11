using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkClass Signatire: 0x75585ef6 size: 80 flags: FLAGS_NONE

    // m_name m_class:  Type.TYPE_CSTRING Type.TYPE_VOID arrSize: 0 offset: 0 flags: FLAGS_NONE enum: 
    // m_parent m_class: hkClass Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 8 flags: FLAGS_NONE enum: 
    // m_objectSize m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_numImplementedInterfaces m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 20 flags: FLAGS_NONE enum: 
    // m_declaredEnums m_class: hkClassEnum Type.TYPE_SIMPLEARRAY Type.TYPE_STRUCT arrSize: 0 offset: 24 flags: FLAGS_NONE enum: 
    // m_declaredMembers m_class: hkClassMember Type.TYPE_SIMPLEARRAY Type.TYPE_STRUCT arrSize: 0 offset: 40 flags: FLAGS_NONE enum: 
    // m_defaults m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 56 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_attributes m_class: hkCustomAttributes Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 64 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_flags m_class:  Type.TYPE_FLAGS Type.TYPE_UINT32 arrSize: 0 offset: 72 flags: FLAGS_NONE enum: FlagValues
    // m_describedVersion m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 76 flags: FLAGS_NONE enum: 
    public partial class hkClass : IHavokObject
    {
        public string m_name { set; get; } = "";
        public hkClass? m_parent { set; get; } = default;
        public int m_objectSize { set; get; } = default;
        public int m_numImplementedInterfaces { set; get; } = default;
        public object? m_declaredEnums { set; get; } = default;
        public object? m_declaredMembers { set; get; } = default;
        private object? m_defaults { set; get; } = default;
        private hkCustomAttributes? m_attributes { set; get; } = default;
        public uint m_flags { set; get; } = default;
        public int m_describedVersion { set; get; } = default;

        public virtual uint Signature => 0x75585ef6;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_name = des.ReadStringPointer(br);
            m_parent = des.ReadClassPointer<hkClass>(br);
            m_objectSize = br.ReadInt32();
            m_numImplementedInterfaces = br.ReadInt32();
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            des.ReadEmptyPointer(br);
            m_attributes = des.ReadClassPointer<hkCustomAttributes>(br);
            m_flags = br.ReadUInt32();
            m_describedVersion = br.ReadInt32();
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            s.WriteCStringPointer(bw, m_name);
            s.WriteClassPointer(bw, m_parent);
            bw.WriteInt32(m_objectSize);
            bw.WriteInt32(m_numImplementedInterfaces);
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            s.WriteVoidPointer(bw);
            s.WriteClassPointer(bw, m_attributes);
            bw.WriteUInt32(m_flags);
            bw.WriteInt32(m_describedVersion);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {
            m_name = xd.ReadString(xe, nameof(m_name));
            m_parent = xd.ReadClassPointer<hkClass>(xe, nameof(m_parent));
            m_objectSize = xd.ReadInt32(xe, nameof(m_objectSize));
            m_numImplementedInterfaces = xd.ReadInt32(xe, nameof(m_numImplementedInterfaces));
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            m_flags = xd.ReadFlag<FlagValues, uint>(xe, nameof(m_flags));
            m_describedVersion = xd.ReadInt32(xe, nameof(m_describedVersion));
        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteString(xe, nameof(m_name), m_name);
            xs.WriteClassPointer(xe, nameof(m_parent), m_parent);
            xs.WriteNumber(xe, nameof(m_objectSize), m_objectSize);
            xs.WriteNumber(xe, nameof(m_numImplementedInterfaces), m_numImplementedInterfaces);
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            throw new NotImplementedException("TPYE_SIMPLEARRAY");
            xs.WriteSerializeIgnored(xe, nameof(m_defaults));
            xs.WriteSerializeIgnored(xe, nameof(m_attributes));
            xs.WriteFlag<FlagValues, uint>(xe, nameof(m_flags), m_flags);
            xs.WriteNumber(xe, nameof(m_describedVersion), m_describedVersion);
        }
    }
}

