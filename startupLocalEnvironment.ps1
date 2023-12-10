$programList = @(
    [PSCustomObject]@{
        URL = "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe"
        Argument = "C:\Kod\handlaren-backend\handlaren-backend.sln"
    },
    [PSCustomObject]@{
        URL = "C:\Users\Pontus\AppData\Local\Programs\Microsoft VS Code\Code.exe"
        Argument = "C:\Kod\handlaren-frontend\"
    },
    [pscustomobject]@{
        URL = "c:\program files\docker\docker\docker desktop.exe"
    },
    [PSCustomObject]@{
        URL = "C:\Program Files\Git\git-bash.exe"
        Argument = '--cd=C:\Kod\handlaren-backend'
    }
)

foreach ($program in $programList) {
    try {
        Write-Host "startar $($program.URL)";
        if ($program.PSObject.Properties['Argument']) {
            Start-Process -FilePath $program.URL -ArgumentList @($program.Argument)  -ErrorAction Stop
        }
        else{
            Start-Process -FilePath $program.URL -ErrorAction Stop
        }
     
    } catch {
        Write-Host "Error opening $($program.URL): $_"
    }
}

 
