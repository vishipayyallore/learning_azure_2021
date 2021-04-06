# Variables
$SubscriptionName = "Visual Studio Professional Subscription"
$RGName = "rg-az204-azwindows-dev-001"
$LocationName = "EastUS"
$BaseName = "winapr2021"
$VmName = "vm$($BaseName)" ##### Windows computer name cannot be more than 15 characters long
$VNetName = "vnet$($BaseName)"
$SubNetName = "default"
$NsgName = "nsg$($BaseName)"
$PublicDns = "publicdns$($BaseName)$(Get-Random)"
$PortsToOpen = 80,3389
$username = "demouser"
$password = "NoPassword@123$%^&*"
$ImageName = "Win2019Datacenter" 

##### Login
az login
az account set --subscription $SubscriptionName
az account list --output table
az account show

###### Group
az group list --output table
az group create --name $RGName --location $LocationName

##### Virtual Machine
az vm create --resource-group $RGName --name $VmName --image win2016datacenter --authentication-type password --admin-username $username --admin-password "NoPassword@123$%^&*"

##### Opending the ports
az vm open-port --resource-group $RGName --name $VmName --port 80 --priority 900

##### IP Addresses for Remote Access
az vm list-ip-addresses --resource-group $RGName --name $VmName --output table

##### Connect to Windows VM using RPD
mstsc /v:publicIpAddress

##### From Within the newly created VM
PS > Install-WindowsFeature -name Web-Server -IncludeManagementTools

##### **************************
