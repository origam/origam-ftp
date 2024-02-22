#region license
/*
Copyright 2005 - 2020 Advantage Solutions, s. r. o.

This file is part of ORIGAM (http://www.origam.org).

ORIGAM is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

ORIGAM is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with ORIGAM. If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using FluentFTP;
using log4net;
using Origam.Service.Core;
using Renci.SshNet;

namespace Origam.Ftp
{
    public class FtpServiceAgent : IExternalServiceAgent
    {
        private static readonly string Ftp = "FTP";
        private static readonly string Ftps = "FTPS";
        private static readonly string Sftp = "SFTP";
        
        private static readonly ILog log =
            LogManager.GetLogger(typeof(FtpServiceAgent));

        public object Result { get; private set; }
        public Hashtable Parameters { get; } = new Hashtable();
        public string MethodName { get; set; }
        public string TransactionId { get; set; }

        public void Run()
        {
            switch (MethodName)
            {
                case "DownloadFile":
                    Result = DownloadFile(
                        protocol:Parameters.Get<string>("Protocol"),
                        host:Parameters.Get<string>("Host"),
                        port:Parameters.TryGet<int?>("Port"),
                        username:Parameters.Get<string>("Username"),
                        password:Parameters.Get<string>("Password"),
                        path:Parameters.Get<string>("Path"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"MethodName",
                    MethodName);
            }   
        }
        private static object DownloadFile(
            string protocol,
            string host,
            int? port,
            string username,
            string password,
            string path)
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat(
                    "Downloading {0} from {1} via {2} protocol.", 
                    path, host, protocol);
            }
            if (string.Equals(protocol, Ftp, 
                StringComparison.InvariantCultureIgnoreCase) 
            || string.Equals(protocol, Ftps, 
                StringComparison.InvariantCultureIgnoreCase))
            {
                return DownloadFileViaFtpClient(
                    protocol, host, port, username, password, path);
            }
            if (string.Equals(protocol, Sftp, 
                StringComparison.InvariantCultureIgnoreCase))
            {
                return DownloadFileViaSftpClient(
                    host, port, username, password, path);
            }
            throw new Exception($"Protocol {protocol}is not supported.");
        }

        private static object DownloadFileViaFtpClient(
            string protocol,
            string host,
            int? port,
            string username,
            string password,
            string path)
        {
            using (var ftp = port == null 
                       ? new FtpClient(host, username, password)
                       : new FtpClient(host, port.Value, username, password))
            {
                if (protocol == Ftps)
                {
                    ftp.EncryptionMode = FtpEncryptionMode.Explicit;
                }
                ftp.Connect();
                using (var output = new MemoryStream())
                {
                    ftp.Download(output, path);
                    return output.ToArray();
                }
            }
        }

        private static object DownloadFileViaSftpClient(
            string host,
            int? port,
            string username,
            string password,
            string path)
        {
            using (var sftp = port == null 
                       ? new SftpClient(host, username, password)
                       : new SftpClient(host, port.Value, username, password))
            {
                sftp.Connect();
                using (var output = new MemoryStream())
                {
                    sftp.DownloadFile(path, output);
                    return output.ToArray();
                }
            }
        }
    }
}