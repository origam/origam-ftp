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
using FluentFTP;
using log4net;
using Origam.Service.Core;

namespace Origam.Ftp
{
    public class FtpServiceAgent : IExternalServiceAgent
    {
        private static readonly ILog log =
            LogManager.GetLogger(typeof(FtpServiceAgent));

        public object Result { get; private set; }
        public Hashtable Parameters { get; } = new Hashtable();
        public string MethodName { get; set; }
        public string TransactionId { get; set; }

        public void Run()
        {
            var useSecuredConnection = true;
            if (Parameters["UseSecuredConnection"] is bool useSecuredConnectionParam)
            {
                useSecuredConnection = useSecuredConnectionParam;
            }
            switch (MethodName)
            {
                case "DownloadFile":
                    Result = DownloadFile(
                    Parameters.Get<string>("Host"),
                    useSecuredConnection,
                    Parameters.Get<string>("Username"),
                    Parameters.Get<string>("Password"),
                    Parameters.Get<string>("Path"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"MethodName",
                    MethodName);
            }   
        }
        private static object DownloadFile(
            string host,
            bool useSecuredConnection,
            string username,
            string password,
            string path)
        {
            if (log.IsDebugEnabled)
            {
                log.DebugFormat(
                    "Downloading {0} from {1}.", path, host);
            }

            using (FtpClient ftp = new FtpClient(host, username, password))
            {
                if (useSecuredConnection)
                {
                    ftp.EncryptionMode = FtpEncryptionMode.Explicit;
                }
                ftp.Connect();
                using (MemoryStream output = new MemoryStream())
                {
                    ftp.Download(output, path);
                    return output.ToArray();
                }
            }
        }
    }
}