using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace VARLightControl
{
    /// <summary>
    /// INI文件操作类 INI file operation class
    /// </summary>
    public static class INIHelper
    {
        /// <summary>
        /// Gets the string for the node specified in the INI file
        /// </summary>
        /// <param name="lpAppName">The name of the node to look for the keyword in</param>
        /// <param name="lpKeyName">The name of the item to get</param>
        /// <param name="lpDefault">The default value returned when the specified item is not found</param>
        /// <param name="lpReturnedString">Specify a string buffer with a length of at least nSize</param>
        /// <param name="nSize">Specifies the maximum number of characters loaded into the lpReturnedString buffer</param>
        /// <param name="lpFileName">INI file full path</param>
        /// <returns>The number of bytes copied to the lpReturnedString buffer, not including those NULL terminating characters</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// Modify the content in the INI file
        /// </summary>
        /// <param name="lpApplicationName">The name of the node to write to</param>
        /// <param name="lpKeyName">Item name to be set</param>
        /// <param name="lpString">the new string to write</param>
        /// <param name="lpFileName">INI file full path</param>
        /// <returns>Non-zero for success, zero for failure</returns>
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key,
            string def, Byte[] retVal, int size, string filePath);

        /// <summary>
        /// 读取INI文件值
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="key">键</param>
        /// <param name="def">未取到值时返回的默认值</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>读取的值</returns>
        public static string Read(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

        /// <summary>
        /// 写INI文件值
        /// </summary>
        /// <param name="section">欲在其中写入的节点名称</param>
        /// <param name="key">欲设置的项名</param>
        /// <param name="value">要写入的新字符串</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int Write(string section, string key, string value, string filePath)
        {
            CheckPath(filePath);
            return WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// 删除节
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int DeleteSection(string section, string filePath)
        {
            return Write(section, null, null, filePath);
        }


        public static List<string> ReadSections(string iniFilename)     // Accept ini file as a string
        {
            List<string> result = new List<string>();
            Byte[] buf = new Byte[65536];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, iniFilename);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }

        /// <summary>
        /// 删除键的值
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="key">键名</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int DeleteKey(string section, string key, string filePath)
        {
            return Write(section, key, null, filePath);
        }

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static void CheckPath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentNullException("filePath");
            }
        }
    }
}
