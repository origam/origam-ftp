# origam-ftp
**Origam** workflow service agent for FTP access.

Supported **Origam** versions: 2022.1+.

## How to use
Reference `origam-ftp` package in your **Origam** project, add the compiled dlls to the server instance folder and adjust 
 `Origam.ServerCore.deps.json`.
```json
# add this to targets
"FluentFTP/32.3.1": {
    "dependencies": {
      "System.Console": "4.3.0",
      "System.IO": "4.3.0",
      "System.Net.NameResolution": "4.3.0",
      "System.Net.Security": "4.3.0",
      "System.Net.Sockets": "4.3.0",
      "System.Runtime": "4.3.0",
      "System.Threading.Tasks": "4.3.0",
      "System.Threading.Thread": "4.3.0"
    },
    "runtime": {
      "lib/netstandard2.0/FluentFTP.dll": {
        "assemblyVersion": "32.3.1.0",
        "fileVersion": "32.3.1.0"
      }
    },
    "compile": {
      "lib/netstandard2.0/FluentFTP.dll": {}
    }
  }
```
```json
# add this to libraries
"FluentFTP/32.3.1": {
  "type": "package",
  "serviceable": true,
  "sha512": "sha512-Worl3dtG1Kw7gHlNGIUZhJiEPZ5LytLhrMtdyBwlY0foR6/nRJg2dV5ZdFBLw0CNwQ2RxLlcrqnaiFDnG/wr2g==",
  "path": "fluentftp/32.3.1",
  "hashPath": "fluentftp.32.3.1.nupkg.sha512"
}
```