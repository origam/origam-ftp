# origam-ftp
**Origam** workflow service agent for FTP access.

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
}
```
```json
# add this to libraries
"FluentFTP/37.0.2": {
  "type": "package",
  "serviceable": true,
  "sha512": "sha512-UW2svrugWPVK7g6heJjGbsWIBPhJHOtMmp1g4NijSTd3z8f+qxg8kv8cIzAWfxusjCRThIHpJts2PHjbg0SOKQ==",
  "path": "fluentftp/37.0.2",
  "hashPath": "fluentftp.37.0.2.nupkg.sha512"
}
```
