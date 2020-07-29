$currentPwd = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Source);

function GoToAcademic {
    Set-Location $currentPwd;
}