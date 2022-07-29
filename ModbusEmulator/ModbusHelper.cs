using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusEmulator
{
    public class ModbusHelper
    {
        public byte[] GetModbusCommand(ModbusProps mProps)
        {
            byte[] command = { (byte)mProps.Addr, (byte)mProps.FuncCode };
            byte[] startRegister = BitConverter.GetBytes(mProps.RegisterStart).Reverse().ToArray();
            byte[] regCount = BitConverter.GetBytes(mProps.RegisterCount).Reverse().ToArray();
            command = command.Concat(startRegister).Concat(regCount).ToArray();
            byte[] byteCrc = Crc.CRCCalc(command);
            command = command.Concat(byteCrc).ToArray();
            return command;
        }
    }
}
