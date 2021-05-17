# Variables
$SubscriptionName = "SwamyPKV VSPS"
$RGName = "rg-az204-arm-pswindows-dev-001"
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

Get-AzResourceGroup | Format-Table
New-AzResourceGroup -Name $RGName -Location $LocationName -Tag @{environment="dev"; Contact="Swamy"}

New-AzResourceGroupDeployment -ResourceGroupName $RGName -TemplateFile .\windowsvm.deploy.json -TemplateParameterFile .\windowsvm.parameters.json

Get-AzNetworkSecurityGroup -ResourceGroupName $RGNAME | Select-Object name

Get-AzNetworkSecurityGroup -ResourceGroupName $RGNAME `
| Add-AzNetworkSecurityRuleConfig -Name "port_80" -Description "Allow port 80" -Access "Allow" -Protocol "Tcp" `
-Direction "Inbound" -Priority 100 -SourceAddressPrefix "Internet" -SourcePortRange "*" -DestinationAddressPrefix "*" -DestinationPortRange "80" `
| Set-AzNetworkSecurityGroup

Get-AzPublicIpAddress `
    -ResourceGroupName $RGName `
     | Select-Object IpAddress

mstsc /v:publicIpAddress

# From within the newly created VM
# PS:> 
Install-WindowsFeature -name Web-Server -IncludeManagementTools

# visit the URL
http://IpAddress-Of-Newly-Created-VM

Stop-AzVm -Name $VmName -ResourceGroupName $RGName

Remove-AzVM -Name $VmName -ResourceGroupName $RGName

Remove-AzResourceGroup -Name $RGName
