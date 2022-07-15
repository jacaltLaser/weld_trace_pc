using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace 星链激光制管机控制软件
{
    /// <summary>
    /// 通信命令码
    /// </summary>
    public static class Global
    {
        public static List<byte> Com_SeralPortBuff = new List<byte>();


        //通信命令代码定义 :

        /// <summary>
        /// 写_指令		
        /// </summary>
        public const byte DataWrite = 0x00;

        /// <summary>
        /// 读_指令			
        /// </summary>
        public const byte DataRead = 0x01;


        /// <summary>
        /// 激光器命令集
        /// </summary>
        public static class LaserDevice_Commands
        {
            /// <summary>
            /// 帧头_下发激光器指令
            /// </summary>
            public const int DataHead_sendLaserDevice = 0xabcd;
            /// <summary>
            /// 帧头_接收激光器指令
            /// </summary>
            public const int DataHead_receiveLaserDevice = 0xefef;

            /// <summary>
            /// 地址_模块激光器的地址	
            /// </summary>
            public const byte Address_LaserDevice = 0xff;

            /// <summary>
            /// 加密到期信息(只读)	
            /// </summary>
            public const byte LimitEndInfo = 0x29;
            /// <summary>
            /// 激光输出功率（1Byte： 0～100 = 0～100%）
            /// </summary>
            public const byte LaserPower = 0x37;
            /// <summary>
            /// 内外控切换开关	
            /// </summary>
            public const byte ModeSwitch = 0x3a;
            /// <summary>
            /// 红光开关（1Byte：0x55 - 关, 0xAA - 开）
            /// </summary>
            public const byte RedSwitch = 0x3b;
            /// <summary>
            /// 出光控制开关(只读)
            /// </summary>
            public const byte MCU_Switch = 0x3c;
            /// <summary>
            /// 内控START 键功能(只写)
            /// </summary>
            public const byte SIM_Ctrl = 0x3d;
            /// <summary>
            /// 内控使能
            /// </summary>
            public const byte SIM_EN = 0x3e;
            /// <summary>
            /// 内控调制信号频率
            /// </summary>
            public const byte SIM_MOD_FREQ = 0x3f;
            /// <summary>
            /// 内控调制信号脉宽
            /// </summary>
            public const byte SIM_MOD_PW = 0x40;
            /// <summary>
            /// 激光器报警信息(只读)（4Bytes）
            /// </summary>
            public const byte AlarmInfo = 0x80;
            /// <summary>
            /// 激光器状态信息1(只读)（2Bytes）
            /// </summary>
            public const byte StateInfo1 = 0x87;
            /// <summary>
            /// 激光器状态信息2(只读)
            /// </summary>
            public const byte StateInfo2 = 0x9c;

        }
        /// <summary>
        /// 控制板命令集
        /// </summary>
        public static class ContrlBoard_Commands
        {
            /// <summary>
            /// 帧头_下发控制板指令
            /// </summary>
            public const int DataHead_sendContrlBoard = 0xbadc;
            /// <summary>
            /// 帧头_接收控制板指令
            /// </summary>
            public const int DataHead_receiveContrlBoard = 0xfefe;

            /// <summary>
            /// 地址_模块控制板的地址	
            /// </summary>
            public const byte Address_ContrlBoard = 0x00;

            /// <summary>
            /// 电机X角度（角度*1.8°）
            /// </summary>
            public const byte MotorAngle_X = 0x00;
            /// <summary>
            /// 电机Y角度（角度*1.8°）
            /// </summary>
            public const byte MotorAngle_Y = 0x01;
            /// <summary>
            /// 电机Z角度（角度*1.8°）
            /// </summary>
         //   public const byte MotorAngle_Z = 0x02;

            /// <summary>
            /// 保护气操作（0x00为关，0x01为开）
            /// </summary>
        //    public const byte ShieldGasOpera = 0x03;

            /// <summary>
            /// 焊接操作（0x00为关，0x01为开）
            /// </summary>
         //   public const byte WeldingOpera = 0x02;

            /// <summary>
            /// 水箱操作（0x00为关，0x01为开）
            /// </summary>
       //     public const byte WaterTankOpera = 0x05;

            /// <summary>
            /// 空调操作（0x00为关，0x01为开）
            /// </summary>
       //     public const byte AirConditionerOpera = 0x06;

            /// <summary>
            /// 报警信息
            /// </summary>
            public const byte AlarmInfo = 0x03;

            /// <summary>
            /// 当前温度（温度*0.1℃）
            /// </summary>
            public const byte CurrTemper = 0x04;

            /// <summary>
            /// 当前湿度（湿度*0.1%RH）
            /// </summary>   
            public const byte CurrHumidity = 0x05;

            /// <summary>
            /// 当前焊接长度（长度*0.1m）
            /// </summary>
            public const byte CurrWeldLength = 0x06;

            /// <summary>
            /// 总焊接长度（长度*0.1m）
            /// </summary>
            public const byte TotaWeldLength = 0x07;

            /// <summary>
            /// 当前机器时间
            /// </summary>
            public const byte CurrMachineTime = 0x08;

            /// <summary>
            /// 在线升级
            /// </summary>
         //   public const byte ProgramUpdate = 0x0d;

            /// <summary>
            /// 焊缝跟踪开关（0x00为关，0x01为开）
            /// </summary>
            public const byte WeldTrackingSwitch = 0x09;

            /// <summary>
            /// 焊缝位置坐标
            /// </summary>
            public const byte WeldPosition = 0x0a;

            /// <summary>
            /// 查询以上所有参数
            /// </summary>
            public const byte AllParameter = 0xff;
        }
    }

    /// <summary>
    /// 通信类
    /// </summary>
    public static class Common
    {
        public static byte[] Lastdata = new byte[200];
        public static string origin_Data;
        public static byte LastGlobal;//最近发送的命令

        /// <summary>
        /// 发送数据队列 向PC集控
        /// </summary>
        public static Queue<byte[]> SendQueue_PC = new Queue<byte[]>();//发送数据队列 向PC集控
        /// <summary>
        /// 命令发送的队列
        /// </summary>
        public static Queue<byte[]> CommandQueue_PC = new Queue<byte[]>();//发送数据队列 
        /// <summary>
        /// 数据接收集合
        /// </summary>
        public static List<byte[]> m_ListRecData = new List<byte[]>();//接收到的数据集合
        /// <summary>
        /// 数据接收锁
        /// </summary>
        public readonly static object ojbSockeRec = new object();//接收锁
        /// <summary>
        /// 发送命令锁
        /// </summary>
        public readonly static object ojbSockeSend_PC = new object();// 发送锁

        /// <summary>
        /// 正确的连接串行端口
        /// </summary>
        public static SerialPort Connect_SerialPort = null;
        public static bool IsConnect = false;//是否连接成功
        public static int Connect_Count = 0;//尝试连接次数


        /// <summary>    
        /// 生成通信格式的数据指令
        /// </summary>
        /// <param name="header">数据帧头</param>
        /// <param name="addr">模块地址</param>
        /// <param name="readORwrite">读写</param>
        /// <param name="command">命令</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static byte[] generateSendData(int header, int addr, byte readORwrite, byte command, byte[] data = null)
        {
            if (data == null)
            {
                if (addr == Global.ContrlBoard_Commands.Address_ContrlBoard)
                {
                    data = new byte[] { 0x00 };
                }
                else
                {
                    data = new byte[] { };
                }
            }

            int dataLength = 4 + data.Length;       //计算长度（不包含帧头和长度（2+1））
            byte[] sendDataArray = new byte[3 + dataLength];

            sendDataArray[0] = (byte)(header / 256);     			//帧头
            sendDataArray[1] = (byte)(header % 256);     			//帧头
            sendDataArray[2] = (byte)(dataLength);     			    //长度
            sendDataArray[3] = (byte)addr;  		 	            //模块地址
            sendDataArray[4] = readORwrite;                         //读写
            sendDataArray[5] = command;                             //具体命令

            for (int i = 0; i < data.Length; i++)                   //数据
                sendDataArray[6 + i] = data[i];

            int checkSum = 0;
            for (int j = 0; j < sendDataArray.Length - 1; j++)
                checkSum += sendDataArray[j];

            checkSum = checkSum % 256;
            sendDataArray[sendDataArray.Length - 1] = (byte)checkSum; //校验码


            byte[] TempBuf = new Byte[sendDataArray.Length];
            for (int i = 0; i < sendDataArray.Length; i++)
            {
                TempBuf[i] = sendDataArray[i];
            }


            return TempBuf;

        }








        public static List<SerialPort> serialPort = new List<SerialPort>();//串口实例化创建  
        public static string[] ComPort = new string[0];//可用串口

        /// <summary>
        /// 获取串口列表的方法
        /// </summary>
        /// <returns></returns>
        public static string[] GetSerialPort()   //获取串口列表                                             
        {
            /////方法一 :
            //List<string> Ports = new List<string>();
            //RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            //if (keyCom != null)
            //{
            //    string[] sSubKeys = keyCom.GetValueNames();
            //    for (int i = 0; i < sSubKeys.Count(); i++)
            //    {
            //        if (sSubKeys[i].StartsWith("\\Device\\ProlificSerial") || sSubKeys[i].StartsWith("\\Device\\Silabser"))
            //        {
            //            string sValue = (string)keyCom.GetValue(sSubKeys[i]);
            //            Ports.Add(sValue);
            //        }
            //    }
            //}
            //return Ports.ToArray();


            /////方法二 :
            return SerialPort.GetPortNames();//获取可用串口字符串
        }

        /// <summary>
        /// 根据查找的串口创建串口对象
        /// </summary>      
        public static bool CreateSerialPort()
        {
            try
            {
                string[] newPort = GetSerialPort();
                if (!newPort.SequenceEqual(ComPort))
                {
                    ComPort = newPort;

                    serialPort.Clear();
                    if (ComPort.Count() > 0)
                    {
                        for (int i = 0; i < ComPort.Count(); i++)
                        {
                            SerialPort sPort = new SerialPort();
                            InitSerialPort(sPort, ComPort[i]);
                            serialPort.Add(sPort);
                        }
                        return true;
                    }
                    else
                    {
                        // MessageBox.Show("没有找到可用串口！请检查设备与计算机是否连接正常", "设备通信", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ComPort = null;
                MessageBox.Show(ex.Message + " 在" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf('\\')), "设备通信", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        /// <summary>
        /// 串口初始化
        /// </summary>
        /// <param name="ComID">串口号</param>
        private static void InitSerialPort(SerialPort sPort, string ComID)
        {
            if (sPort.IsOpen)
            {
                sPort.Close();//设置的COM口在用时，不能对COM口属性进行操作。所以必须先判断当前COM口是否在用。
                //还要弹出提示“COM?正在另一个程序使用。继续使用此COM口可能不能正常通信，是否继续使用COM?？"            
            }
            if (ComID == "")
            {
                return;
            }
            sPort.PortName = ComID;
            sPort.BaudRate = 115200;
            sPort.StopBits = StopBits.One;
            sPort.DataBits = 8;
            sPort.Parity = Parity.None;
            sPort.ReceivedBytesThreshold = 1;
            sPort.ReadTimeout = -1;
            sPort.WriteTimeout = -1;
        }

        /// <summary>
        /// 打开串口,并注册接收事件
        /// </summary>
        public static string OpenSerialPort(SerialPort sPort)
        {
            if (!sPort.IsOpen)//如果串口对象处于关闭状态
            {
                try
                {
                    sPort.Open(); //打开串口
                    sPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived);// 注册接收事件
                }
                catch (System.IO.IOException)
                {
                    //   MessageBox.Show("通信串口" + sPort.PortName + "已断开连接！", " 设备通信", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sPort.Close();//关闭串口
                    return "通信串口" + sPort.PortName + "已断开连接！";
                }
                catch (System.UnauthorizedAccessException)
                {
                    //MessageBox.Show("通信串口" + sPort.PortName + "已被其他程序占用！", " 设备通信", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sPort.Close();//关闭串口
                    return "通信串口" + sPort.PortName + "已被其他程序占用！";
                }
            }
            return "";
        }

        /// <summary>
        /// 关闭串口，并注销接收事件
        /// </summary>
        public static void CloseSerialPort()
        {
            foreach (SerialPort sPort in serialPort)
            {
                if (sPort.IsOpen)//如果串口处于开启状态
                {
                    try
                    {
                        sPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived); // 注销接收事件 
                        sPort.Close();//关闭串口，并注销
                                      //   sPort.Dispose();                        
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show("通信串口" + sPort.PortName + "无法正常关闭！" + ex.ToString(), "设备通信", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

  

        /// <summary>
        /// 串口接收事件
        /// </summary>
        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sPort = sender as SerialPort;//获取当前接收数据的串口

            int n = 0;
            if (sPort.IsOpen)
            {
                n = sPort.BytesToRead;
            }
            else
            {
                return;
            }
            byte[] buf = new byte[n];
            sPort.Read(buf, 0, n);
            if (buf.Length > 0)
            {
                Global.Com_SeralPortBuff.AddRange(buf); //接收ADC缓存值
            }
            while (Global.Com_SeralPortBuff.Count >= 8)
            {
                int header = Global.Com_SeralPortBuff[0] * 256 + Global.Com_SeralPortBuff[1];
                if (header == Global.LaserDevice_Commands.DataHead_receiveLaserDevice || header == Global.ContrlBoard_Commands.DataHead_receiveContrlBoard)
                {
                    int m_len = Global.Com_SeralPortBuff[2] + 3;//数据长度(不包含帧头和长度，所以+3) 
                    //if (m_len > 25)//数据长度大于最大数据长度22
                    //{
                    //    Global.Com_SeralPortBuff.Clear();
                    //}
                    if (Global.Com_SeralPortBuff.Count < m_len)
                        break;

                    int CheckSum = 0;
                    for (int t = 0; t < m_len - 1; t++) //数据校验
                    {
                        CheckSum += Global.Com_SeralPortBuff[t];
                    }
                    CheckSum = CheckSum % 256;

                    #region 数据校验========================================
                    if (CheckSum == Global.Com_SeralPortBuff[m_len - 1])//数据正确的处理；
                    {
                        byte[] m_TempAry = new byte[m_len];
                        for (int k = 0; k < m_len; k++)
                        {
                            m_TempAry[k] = Global.Com_SeralPortBuff[k];
                        }

                        //数据校验正确处理===========================================================
                        lock (Common.ojbSockeRec)
                        {
                            Common.m_ListRecData.Add(m_TempAry);
                            Global.Com_SeralPortBuff.RemoveRange(0, m_len);
                        }

                        IsConnect = true;
                        Connect_Count = 0;
                        Connect_SerialPort = sPort;
                    }
                    else
                    {
                        Global.Com_SeralPortBuff.RemoveRange(0, m_len);//移除不正确的数据；
                    }

                    #endregion

                }
                else
                {
                    Global.Com_SeralPortBuff.RemoveAt(0);
                }

            }
        }








        /// <summary>
        /// 错误信息的提示和日志记录
        /// </summary>
        /// <param name=""></param>
        public static void Error_TipsAndLogs(string errStr, Exception except, string title = "", MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Asterisk)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(except, true);
            string fileName = trace.GetFrame(0).GetMethod().ReflectedType.FullName; //文件名
            string Method = trace.GetFrame(0).GetMethod().Name;  //函数名
            int LineNumbe = trace.GetFrame(0).GetFileLineNumber();//文件行号

            MessageBox.Show(errStr + "\n出错对象类 :" + fileName + "\n执行函数名 :" + Method + "\n行号 :" + LineNumbe, title, messageBoxButtons, messageBoxIcon);
        }

        /// <summary>
        /// 错误所在位置信息
        /// </summary>
        /// <param name=""></param>
        public static string Error_pos(Exception except)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(except, true);
            string fileName = trace.GetFrame(0).GetMethod().ReflectedType.FullName; //文件名
            string Method = trace.GetFrame(0).GetMethod().Name;  //函数名
            int LineNumbe = trace.GetFrame(0).GetFileLineNumber();//文件行号

            return "\n出错对象类 :" + fileName + "；执行函数名 :" + Method + "；行号 :" + LineNumbe + "\n";
        }

        /// <summary>
        /// 一个16制字节数组，从起点下标index开始连续n2个字节，转为字符串
        /// </summary>
        /// <param name="byteData">一个字节数组</param>
        /// <param name="index">起点下标</param>
        /// <param name="len">n2个字节</param>
        /// <returns></returns>
        public static string HexBytesToString(Byte[] byteData, int index, int len)
        {
            string strData = "";
            for (int i = 0; i < len; i++)
            {
                strData += byteData[index + i].ToString("X2");//先转成字符串  06 98 即698kpa                
            }
            return strData;
        }

        /// <summary>
        /// Ascii转字符串
        /// </summary>
        /// <param name="ascii"></param>
        /// <returns></returns>
        public static string AsciiToString(string ascii)
        {
            string returnValue = "";
            string s = "";
            for (int i = 0; i < ascii.Length; i = i + 2)
            {
                s = ascii.Substring(i, 2);
                if (s == "FF" || s == "00" || s == "2B")
                    continue;
                int temp = Convert.ToInt32(s, 16);


                if (temp >= 0 && temp <= 255)
                {
                    returnValue += System.Text.Encoding.ASCII.GetString(new byte[] { (byte)temp });
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 16进制浮点字符串转十进制浮点数
        /// </summary>
        /// <param name="hexStr">16进制浮点字符串</param>
        /// <param name="rounding">是否直接舍弃，不进行四舍五入</param>
        /// <returns>十进制浮点数</returns>
        public static float HexStrToFloatStr(string hexStr, bool rounding = false)
        {
            int len = hexStr.Length / 2;
            byte[] floatVals = new byte[4];
            for (int i = 0; i < len; i++)
            {
                string str = hexStr.Substring(i * 2, 2);
                if (str == "FF")
                    continue;
                floatVals[i] = Convert.ToByte(str, 16);
            }

            float f = BitConverter.ToSingle(floatVals, 0);
            if (rounding)
                f = (float)((int)(f * 100) / 100.00);

            return f;
        }

        /// <summary>
        /// 16进制浮点字节数组转十进制浮点数
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static float HexStrToFloatStr(byte[] floatVals)
        {
            float f = BitConverter.ToSingle(floatVals, 0);
            f = (float)((int)(BitConverter.ToSingle(floatVals, 0) * 100) / 100.00);
            return f;
        }


        /// <summary>
        /// 十进制浮点数字符串转16进制浮点字节数组转
        /// </summary>
        /// <param name="Vals"></param>
        /// <returns></returns>
        public static byte[] FloatStrToToBytes(string Vals)
        {
            float floatVals = Convert.ToSingle(Vals);
            byte[] bytefloat = BitConverter.GetBytes(floatVals);

            return bytefloat;
        }


        /// <summary>
        /// 将int数值转换为指定长度的byte数组
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static byte[] IntToBytes(int number, int len)
        {
            byte[] bytes = new byte[len];
            for (int i = 0; i < len; i++)
            {
                bytes[i] = (byte)(number >> 8 * i);
            }
            return bytes;
        }

        /// <summary>
        /// byte数组转换为int数值
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int bytesToInt(byte[] bytes)
        {
            int number = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                number += (bytes[i] << 8 * i);
            }
            return number;
        }
    }

    /// <summary>
    /// 公共函数
    /// </summary>
    public static class PublicFunc
    {
        public static Color ChangeColor(Color color, float factor)
        {

            float red = (float)color.R + 10 * factor;
            float green = (float)color.G + 10 * factor;
            float blue = (float)color.B + 10 * factor;

            if (red < 0)
                red = 0;
            if (red > 255)
                red = 255;

            if (green < 0)
                green = 0;
            if (green > 255)
                green = 255;

            if (blue < 0)
                blue = 0;
            if (blue > 255)
                blue = 255;


            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
    }

}