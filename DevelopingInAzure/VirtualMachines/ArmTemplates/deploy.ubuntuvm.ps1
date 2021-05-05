$SubscriptionName = "Visual Studio Professional Subscription"
$RGName = "rg-az204-armpsubuntu-dev-001"
$LocationName = "eastus"

Connect-AzAccount
Set-AzContext -SubscriptionName $SubscriptionName

#use this command when you need to create a new resource group for your deployment
New-AzResourceGroup -Name $RGName -Location $LocationName 

##### get-help New-AzResourceGroupDeployment -examples
New-AzResourceGroupDeployment -ResourceGroupName $RGName -TemplateFile "./ubuntuvm.deploy.json" -TemplateParameterFile "./ubuntuvm.parameters.json" -Tag @{"environment"="dev"; "contact"="NoName";}

Get-AzNetworkSecurityGroup -Name "SecGroupNet" -ResourceGroupName $RGName | Add-AzNetworkSecurityRuleConfig -Name "Web-Rule" -Description "Allow Web" -Access "Allow" -Protocol "Tcp" -Direction "Inbound" -Priority 100 -SourceAddressPrefix "Internet" -SourcePortRange "*" -DestinationAddressPrefix "*" -DestinationPortRange "80" | Set-AzNetworkSecurityGroup

##### From PowerShell
> ssh -i C:\Users\PK.Viswanatha-Swamy\.ssh\id_rsa demouser@52.255.149.104

##### Inside the Ubuntu VM
##### sudo apt update && sudo apt install -y lamp-server^

# visit the URL
http://52.255.149.104
