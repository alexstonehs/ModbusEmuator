using System;
using System.Text;

namespace ModbusEmulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModbusProps props = new ModbusProps();
            ModbusHelper modbusHelper = new ModbusHelper();
            props.Addr = 1;
            props.RegisterStart = 3;
            props.RegisterCount = 1;
            props.FuncCode = 3;//读模拟量的命令号固定为03，这是Modbus协议规定的。
            var data = modbusHelper.GetModbusCommand(props);
            Console.WriteLine(ByteToHexStr(data));
            Console.ReadLine();
        }
        static string ByteToHexStr(byte[] bytes)
        {
            string hexStr = "";
            StringBuilder sb = new StringBuilder();
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));
                }
            }

            hexStr = sb.ToString();
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < hexStr.Length;)
            {
                sb2.Append($"{hexStr[i++]}{hexStr[i++]} ");
            }

            var returnStr = sb2.ToString().TrimEnd();
            return returnStr;
        }
    }
}
