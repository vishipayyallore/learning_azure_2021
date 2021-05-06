$SubscriptionName = "Visual Studio Professional Subscription"
$RGName = "rg-az204-arm-psubuntu-dev-001"
$LocationName = "eastus"

Connect-AzAccount
Set-AzContext -SubscriptionName $SubscriptionName

#use this command when you need to create a new resource group for your deployment
New-AzResourceGroup -Name $RGName -Location $LocationName 

##### Please ensure that updated SSH keys are present in parameters.json
##### get-help New-AzResourceGroupDeployment -examples
New-AzResourceGroupDeployment -ResourceGroupName $RGName -TemplateFile "./ubuntuvm.deploy.json" -TemplateParameterFile "./ubuntuvm.parameters.json"

##### Open the Port 80
Get-AzNetworkSecurityGroup -Name "SecGroupNet" -ResourceGroupName $RGName | Add-AzNetworkSecurityRuleConfig -Name "Web-Rule" -Description "Allow Web" -Access "Allow" -Protocol "Tcp" -Direction "Inbound" -Priority 100 -SourceAddressPrefix "Internet" -SourcePortRange "*" -DestinationAddressPrefix "*" -DestinationPortRange "80" | Set-AzNetworkSecurityGroup

##### Retrieve the Public Ip Address
Get-AzPublicIpAddress -ResourceGroupName $RGName | Select-Object IpAddress

##### From PowerShell
> ssh -i C:\Users\PK.Viswanatha-Swamy\.ssh\id_rsa demouser@13.92.209.232

##### Inside the Ubuntu VM
##### sudo apt update && sudo apt install -y lamp-server^

# visit the URL
http://13.92.209.232
