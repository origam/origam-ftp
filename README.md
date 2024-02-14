# origam-ftp
**Origam** workflow service agent for FTP access. Supported protocols are FTP, FTPS an SFTP.

Supported **Origam** versions: 2022.1+.

## How to use
Reference `origam-ftp` package in your **Origam** project, add the compiled dlls to the server instance folder and adjust 
 `Origam.ServerCore.deps.json` or `Origam.Server.deps.json` depending on used **Origam** version.
```json
# add this to targets
"FluentFTP/37.0.2": {
  "runtime": {
    "lib/net5.0/FluentFTP.dll": {
      "assemblyVersion": "37.0.2.0",
      "fileVersion": "37.0.2.0"
    }
  },
  "compile": {
    "lib/net5.0/FluentFTP.dll": {}
  }
},
"SSH.NET/2023.0.1": {
  "dependencies": {
    "Microsoft.Bcl.AsyncInterfaces": "8.0.0",
     "SshNet.Security.Cryptography": "1.3.0"
  },
  "runtime": {
    "lib/netstandard2.0/Renci.SshNet.dll": {
      "assemblyVersion": "2023.0.1.0",
      "fileVersion": "2023.0.1.0"
    }
  }
},
"SshNet.Security.Cryptography/1.3.0": {
  "runtime": {
    "lib/netstandard2.0/SshNet.Security.Cryptography.dll": {
      "assemblyVersion": "1.3.0.0",
      "fileVersion": "1.3.0.0"
    }
  }
},
```
```json
# add this to libraries
"FluentFTP/37.0.2": {
  "type": "package",
  "serviceable": true,
  "sha512": "sha512-UW2svrugWPVK7g6heJjGbsWIBPhJHOtMmp1g4NijSTd3z8f+qxg8kv8cIzAWfxusjCRThIHpJts2PHjbg0SOKQ==",
  "path": "fluentftp/37.0.2",
  "hashPath": "fluentftp.37.0.2.nupkg.sha512"
},
"SSH.NET/2023.0.1": {
  "type": "package",
  "serviceable": true,
  "sha512": "sha512-ZDA87AMfRonF+FtCfMkA4CiH9wWpxkqmnIcs+rZ234AJFRVZb1nI9OSb4wNAb/CiJH4ZEqA27/Xj+Btdnakk3A==",
  "path": "ssh.net/2023.0.1",
  "hashPath": "ssh.net.2023.0.1.nupkg.sha512"
},
"SshNet.Security.Cryptography/1.3.0": {
  "type": "package",
  "serviceable": true,
  "sha512": "sha512-5pBIXRjcSO/amY8WztpmNOhaaCNHY/B6CcYDI7FSTgqSyo/ZUojlLiKcsl+YGbxQuLX439qIkMfP0PHqxqJi/Q==",
  "path": "sshnet.security.cryptography/1.3.0",
  "hashPath": "sshnet.security.cryptography.1.3.0.nupkg.sha512"
}

```
