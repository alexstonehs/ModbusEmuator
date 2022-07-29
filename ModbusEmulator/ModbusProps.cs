using System;
using System.Collections.Generic;
using System.Text;

namespace ModbusEmulator
{
    public class ModbusProps
    {
        private int addr;
        private int funcCode;
        private short registerStart;
        private short registerCount;
        /// <summary>
        /// 从机地址
        /// </summary>
        public int Addr { get => addr; set => addr = value; }
        /// <summary>
        /// 功能码
        /// </summary>
        public int FuncCode { get => funcCode; set => funcCode = value; }
        /// <summary>
        /// 寄存器起始位
        /// </summary>
        public short RegisterStart { get => registerStart; set => registerStart = value; }
        /// <summary>
        /// 寄存器个数
        /// </summary>
        public short RegisterCount { get => registerCount; set => registerCount = value; }
    }
}
