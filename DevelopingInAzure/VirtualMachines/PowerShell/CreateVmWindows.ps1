# Variables
$SubscriptionName = "SwamyPKV VSPS"
$RGName = "rg-az204-pswindows-dev-001"
$LocationName = "EastUS"
$BaseName = "apr2021win"
$VmName = "vm$($BaseName)"
$VNetName = "vnet$($BaseName)"
$SubNetName = "default"
$NsgName = "nsg$($BaseName)"
$PublicDns = "publicdns$($BaseName)$(Get-Random)"
$PortsToOpen = 80, 3389
$username = 'demouser'
$password = ConvertTo-SecureString 'ToBeDone' -AsPlainText -Force
$ImageName = "Win2019Datacenter" 

##### For Help
get-help New-AzResourceGroup

# Connecting to Subscription
Connect-AzAccount
Connect-AzAccount -SubscriptionName $SubscriptionName
Set-AzContext -SubscriptionName $SubscriptionName

# View All subscriptions
Get-AzSubscription

Get-AzVm

Get-AzResourceGroup
New-AzResourceGroup -Name $RGName -Location $LocationName -Tag @{environment="dev"; Contact="Swamy"}

$CredentialsForVm = New-Object System.Management.Automation.PSCredential ($username, $password)

New-AzVm -ResourceGroupName $RGName -Name $VmName -Location $LocationName `
    -Credential $CredentialsForVm -Image $ImageName `
    -VirtualNetworkName $VNetName -SubnetName $SubNetName -SecurityGroupName $NsgName `
    -PublicIpAddressName $PublicDns -OpenPorts $PortsToOpen

Get-AzPublicIpAddress `
    -ResourceGroupName $RGName `
    -Name $PublicDns | Select-Object IpAddress

mstsc /v:publicIpAddress

# From within the newly created VM
# PS:> 
Install-WindowsFeature -name Web-Server -IncludeManagementTools

# visit the URL
http://IpAddress-Of-Newly-Created-VM

Stop-AzVm -Name $VmName -ResourceGroupName $RGName

Remove-AzVM -Name $VmName -ResourceGroupName $RGName

Remove-AzResourceGroup -Name $RGName
