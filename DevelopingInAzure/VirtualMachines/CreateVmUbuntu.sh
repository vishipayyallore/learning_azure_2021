# Variables
$SubscriptionName = "Visual Studio Professional Subscription"
$RGName = "rg-az204-azubuntu-dev-001"
$LocationName = "EastUS"
$BaseName = "apr2021win"
$VmName = "vm$($BaseName)"
$VNetName = "vnet$($BaseName)"
$SubNetName = "default"
$NsgName = "nsg$($BaseName)"
$PublicDns = "publicdns$($BaseName)$(Get-Random)"
$PortsToOpen = 80,3389
$username = 'demouser'
$password = ConvertTo-SecureString 'NoPassword@123$%^&*' -AsPlainText -Force
$ImageName = "Win2019Datacenter" 
