using System;
using System.Collections.Generic;
using System.Text;

namespace ModbusEmulator
{
    internal class Crc
    {
        /// CRC校验
        /// </summary>
        /// <param name="data">校验数据</param>
        /// <returns>高低8位</returns>
        public static byte[] CRCCalc(byte[] datas)
        {
           
            byte[] crcbuf = datas;
            //计算并填写CRC校验码
            int crc = 0xffff;
            int len = crcbuf.Length;
            for (int n = 0; n < len; n++)
            {
                byte i;
                crc = crc ^ crcbuf[n];
                for (i = 0; i < 8; i++)
                {
                    int TT;
                    TT = crc & 1;
                    crc = crc >> 1;
                    crc = crc & 0x7fff;
                    if (TT == 1)
                    {
                        crc = crc ^ 0xa001;
                    }
                    crc = crc & 0xffff;
                }

            }
            byte[] redata = new byte[2];
            redata[1] = (byte)((crc >> 8) & 0xff);
            redata[0] = (byte)((crc & 0xff));
            return redata;
        }
    }
}
