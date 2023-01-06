using System.Xml.Linq;

namespace HKX2
{
    // hkbBlendCurveUtils Signatire: 0x23041af0 size: 1 flags: FLAGS_NONE


    public partial class hkbBlendCurveUtils : IHavokObject
    {
        public byte[] unk0 = new byte[1];

        public virtual uint Signature => 0x23041af0;

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
    }
}

