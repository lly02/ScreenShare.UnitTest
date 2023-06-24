using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenShare.Network.P2P.Payload;

namespace ScreenShare.UnitTest.Network.P2P.Payload
{
    [TestClass]
    public class DecoderTest
    {
        public string AssetString { get; private set; } = @"Assets\WebSocketPayload";

        [TestMethod]
        public void Decode_Payload_Length_10()
        {
            byte[] Payload = Helper.ReadCsv(Path.Join(
                AssetString, 
                @"Length_10\Length_10_Payload.csv"));

            ScreenShare.Network.P2P.Payload.Decoder Decoder = new ScreenShare.Network.P2P.Payload.Decoder();
            Decoder.Decode(Payload);

            Assert.AreEqual(1, Decoder.PayloadData.Count);

            string Result = Encoding.UTF8.GetString(Decoder.PayloadData[0]);
            string Expected = Helper.ReadTxt(Path.Join(
                AssetString, 
                @"Length_10\Length_10_String.txt"));

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod]
        public void Decode_Payload_Length_10000()
        {
            byte[] Payload = Helper.ReadCsv(Path.Join(
                AssetString, 
                @"Length_10000\Length_10000_Payload.csv"));

            ScreenShare.Network.P2P.Payload.Decoder Decoder = new ScreenShare.Network.P2P.Payload.Decoder();
            Decoder.Decode(Payload);

            Assert.AreEqual(1, Decoder.PayloadData.Count);

            string Result = Encoding.UTF8.GetString(Decoder.PayloadData[0]);
            string Expected = File.ReadAllText(Path.Join(
                AssetString,
                @"Length_10000\Length_10000_String.txt"), Encoding.UTF8);

            Assert.AreEqual(Expected, Result);
        }

        [TestMethod]
        public void Decode_Payload_Length_50000()
        {
            byte[] Payload = Helper.ReadCsv(Path.Join(
                AssetString,
                @"Length_50000\Length_50000_Payload.csv"));

            ScreenShare.Network.P2P.Payload.Decoder Decoder = new ScreenShare.Network.P2P.Payload.Decoder();
            Decoder.Decode(Payload);

            Assert.AreEqual(1, Decoder.PayloadData.Count);

            string Result = Encoding.UTF8.GetString(Decoder.PayloadData[0]);
            string Expected = File.ReadAllText(Path.Join(
                AssetString,
                @"Length_50000\Length_50000_String.txt"), Encoding.UTF8);

            Assert.AreEqual(Expected, Result);
        }
    }
}
